using System;
using System.Configuration;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Contract;
using log4net;
using System.Text;
using System.Security.Cryptography;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provades a login form 
    /// </summary>
    public partial class OESLoginFrom : Form
    {
        #region Private Field
        /// <summary>
        /// Represents the mouse key status.
        /// </summary>
        private bool isMouseDown = false;

        /// <summary>
        /// Represents the window start position.
        /// </summary>
        private Point formStartPoint;

        /// <summary>
        /// Represents the mouse start position.
        /// </summary>
        private Point mouserStartPoint;

        private Thread loginAction;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the OESLoginFrom class.
        /// </summary>
        public OESLoginFrom()
        {
            InitializeComponent();

            this.InitializeControlEvent();
            this.InitFormInformation();
            Session.formDictionary.Add(Constants.FormKeyLogin, this);
        }
        #endregion

        #region Intialize Method
        /// <summary>
        /// Initializes control event.
        /// </summary>
        private void InitializeControlEvent()
        {
            this.lblClose.Click += new EventHandler(DoLblCloseClick);
            this.pnlTitleControl.MouseDown += new MouseEventHandler(DoPnlTitleMouseDown);
            this.pnlTitleControl.MouseMove += new MouseEventHandler(DoPnlTitleMouseMove);
            this.pnlTitleControl.MouseUp += new MouseEventHandler(DoPnlTitleMouseUp);
            this.txtUserName.LostFocus += new EventHandler(DoTxtLostFocus);
            this.TxtPassword.LostFocus += new EventHandler(DoTxtLostFocus);
            this.btnLogin.Click += new EventHandler(DoBtnLoginClick);
        }

        /// <summary>
        /// Handles the key down event for the login button.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void DoBtnLoginKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                this.DoBtnLoginClick(sender, e);
            }
            else
            {
                // Nothig to do.
            }
        }

        /// <summary>
        /// Initialzes user information about textBox of user name and password.
        /// </summary>
        private void InitFormInformation()
        {
            string rememberUserName = ConfigurationManager.AppSettings[Constants.RememberUserName].ToString();

            if (!string.IsNullOrEmpty(rememberUserName))
            {
                this.txtUserName.Text = rememberUserName;
                this.chkRememberMe.Checked = true;
            }
            else
            {
                this.chkRememberMe.Checked = false;
            }

            string rememberPassword = ConfigurationManager.AppSettings[Constants.RememberPassword].ToString();

            if (string.IsNullOrEmpty(rememberPassword))
            {
                this.TxtPassword.Text = rememberPassword;
            }
            else
            {
                //Nothing to do.
            }
        }
        #endregion

        #region Event Method
        /// <summary>
        /// Handles the click for the login button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBtnLoginClick(object sender, EventArgs e)
        {
            loginAction = new Thread(DoLoginAction);
            loginAction.Start();
        }

        /// <summary>
        /// Login operation.
        /// </summary>
        private void DoLoginAction()
        {
            string userName = this.txtUserName.Text.Trim();
            string password = this.TxtPassword.Text.Trim();

            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                this.Invoke(new Action(() => 
                {
                    this.SetTipDetial(Constants.LoginAllInformationNotExistMassage, true, true, true);
                }));
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(userName))
                {
                    this.Invoke(new Action(() => 
                    {
                        this.SetTipDetial(Constants.LoginUserNameNotExistMassage, true, false, true);
                    }));
                    return;
                }
                else if (string.IsNullOrEmpty(password))
                {
                    this.Invoke(new Action(() =>
                    {
                        this.SetTipDetial(Constants.LoginPasswordNotExistMassage, false, true, true);
                    }));
                    return;
                }
                else
                {
                    this.Invoke(new Action(() => 
                    {
                        this.SetTipDetial(string.Empty, false, false, false);
                    }));
                }
            }

            try
            {
                User user = null;

                using (ChannelFactory<IUserService> factory = new ChannelFactory<IUserService>(Constants.EndPointUserService))
                {
                    IUserService userService = factory.CreateChannel();
                    byte[] array = Encoding.UTF8.GetBytes(this.TxtPassword.Text.Trim());
                    byte[] computeHash =  new MD5CryptoServiceProvider().ComputeHash(array);
                    string pass = BitConverter.ToString(computeHash).Replace("-", string.Empty);
                    user = userService.Login(this.txtUserName.Text.Trim(), pass);

                }

                if (user == null)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.SetTipDetial(Constants.LoginPasswordWrongMassage, false, true, true);
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        this.SetTipDetial(string.Empty, false, false, false);
                    }));
                    Session.CurrentUser = user;

                    if (this.chkRememberMe.CheckState == CheckState.Checked)
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings.Remove(Constants.RememberUserName);
                        config.AppSettings.Settings.Add(Constants.RememberUserName, user.UserName);
                        config.Save();
                    }
                    else
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings.Remove(Constants.RememberUserName);
                        config.AppSettings.Settings.Add(Constants.RememberUserName, String.Empty);
                        config.Save();
                    }

                    if (user.RoleType == 1)
                    {
                        
                        this.Invoke(new Action(() =>
                        {
                            Session.formDictionary.Add(Constants.FormKeyMain, new StudentMainForm());
                            Session.formDictionary[Constants.FormKeyLogin].Hide();
                            Session.formDictionary[Constants.FormKeyMain].Show();
                        }));
                        
                    }
                    else if (user.RoleType == 2)
                    {
                        this.Invoke(new Action(() =>
                        {
                            Session.formDictionary.Add(Constants.FormKeyMain, new TeacherMainForm());
                            Session.formDictionary[Constants.FormKeyLogin].Hide();
                            Session.formDictionary[Constants.FormKeyMain].Show();
                        }));
                    }
                    this.Invoke(new Action(() =>
                    {
                        this.TxtPassword.Text = string.Empty;
                    }));
                }

            }
            catch (FaultException<UserNameNotExistsException> ex)
            {
                this.Invoke(new Action(() =>
                {
                    this.SetTipDetial(ex.Message, true, false, true);
                }));
            }
            catch (CommunicationException ex)
            {
                this.Invoke(new Action(() =>
                {
                    this.SetTipDetial(ex.Message, false, false, true);
                }));
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    this.SetTipDetial(Constants.ErrorTips, false, false, true);
                    ILog logger = LogManager.GetLogger(this.GetType());
                    logger.Error(ex);
                }));
                
            }
        }

        /// <summary>
        /// Handles the lost focus event for text box.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">eventArgs</param>
        private void DoTxtLostFocus(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null)
            {
                //Nothing to do.
            }
            else
            {
                if (txt == this.txtUserName && string.IsNullOrEmpty(txt.Text))
                {
                    this.SetTipDetial(Constants.LoginUserNameNotExistMassage, true, false, true);
                    return;
                }
                else if (txt == this.TxtPassword && string.IsNullOrEmpty(txt.Text))
                {
                    this.SetTipDetial(Constants.LoginPasswordNotExistMassage, false, true, true);
                    return;
                }
                else
                {
                    this.SetTipDetial(string.Empty, false, false, false);
                }
            }
        }

        /// <summary>
        /// Handles the click event for close button.
        ///     Closes current window and exit project.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoLblCloseClick(object sender, EventArgs e)
        {
            Session.formDictionary[Constants.FormKeyLogin].Close();
            Application.ExitThread();
        }

        /// <summary>
        /// Handles the mouse up event for mouse.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">e</param>
        private void DoPnlTitleMouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        /// <summary>
        /// Handles the mouse move event for mouse.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">e</param>
        private void DoPnlTitleMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isMouseDown = true;
                    Point nowPoint = Control.MousePosition;
                    int xChange = nowPoint.X - mouserStartPoint.X;
                    int yChange = nowPoint.Y - mouserStartPoint.Y;
                    this.Location = new Point(formStartPoint.X + xChange, formStartPoint.Y + yChange);
                }
            }
        }

        /// <summary>
        /// Handles the mouse key down event for mouse.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">e</param>
        private void DoPnlTitleMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                formStartPoint = this.Location;
                mouserStartPoint = Control.MousePosition;
            }
        }
        #endregion

        #region Util Method
        /// <summary>
        /// Sets page tip massage way.
        /// </summary>
        /// <param name="tipMassage">tipMassage</param>
        /// <param name="showUsertip">showUsertip</param>
        /// <param name="showPasswordTip">showPasswordTip</param>
        /// <param name="showTipBox">showTipBox</param>
        private void SetTipDetial(string tipMassage, bool showUsertip, bool showPasswordTip, bool showTipBox)
        {
            if (!string.IsNullOrEmpty(tipMassage) || !tipMassage.Equals(string.Empty))
            {
                this.lblTipMassageBox.Text = tipMassage;
            }
            else
            {
                //Nothing to do.
            }

            if (showUsertip)
            {
                this.lblUserNameTip.Visible = true;
            }
            else
            {
                this.lblUserNameTip.Visible = false;
            }

            if (showPasswordTip)
            {
                this.lblPasswordTip.Visible = true;
            }
            else
            {
                this.lblPasswordTip.Visible = false;
            }

            if (showTipBox)
            {
                this.lblTipMassageBox.Visible = true;
            }
            else
            {
                this.lblTipMassageBox.Visible = false;
            }
        }
        #endregion
    }
}