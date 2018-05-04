using System;
using System.ServiceModel;
using System.Windows.Forms;
using Contract;
using System.Threading;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Privades a ExamResultAbstractForm form.
    /// </summary>
    public partial class ExamResultAbstractForm : BaseForm
    {
        #region Private Field

        /// <summary>
        /// Represents the exam result abstract.
        /// </summary>
        private UserExam userExam;

        /// <summary>
        /// Represents the thread for the page transitions.
        /// </summary>
        private Thread pageTransitions;
        #endregion

        #region Public Field
        /// <summary>
        /// Represents the exam result of submit way.
        /// </summary>
        public bool TimeOut 
        {
            set 
            {
                if (value)
                {
                    this.lblTimeOutMessage.Visible = true;
                }
                else
                {
                    this.lblTimeOutMessage.Visible = false;
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the ExamResultAbstractForm class.
        /// </summary>
        public ExamResultAbstractForm()
        {
            InitializeComponent();
            this.InitData();
            this.InitEvent();
        }
        #endregion

        #region Private Mothod
        /// <summary>
        /// Initializes the event for this form.
        /// </summary>
        private void InitEvent()
        {
            this.pnlTitleControl.MouseDown += new MouseEventHandler(DoPnlTitleMouseDown);
            this.pnlTitleControl.MouseMove += new MouseEventHandler(DoPnlTitleMouseMove);
            this.pnlTitleControl.MouseUp += new MouseEventHandler(DoPnlTitleMouseUp);
            this.lblOpreaClose.Click += new EventHandler(DoLblOpreaCloseClick);
            this.lblOperaMin.Click += new EventHandler(DoLblOperaMinClick);
            this.btnViewDetail.Click += new EventHandler(DoBtnViewDetailClick);
        }

        /// <summary>
        /// Initializes the data for this form.
        /// </summary>
        private void InitData()
        {
            using (ChannelFactory<IExamService> factory = new ChannelFactory<IExamService>(Constants.EndPointExamService))
            {
                IExamService examService = factory.CreateChannel();
                userExam = examService.CheckExamResultAbstract(Session.CurrentExam.Id, Session.CurrentUser.Id);
            }

            this.lblRightCount.Text = userExam.RightCount.ToString();
            this.lblTotalScore.Text = userExam.Score.ToString();
        }

        /// <summary>
        /// Handles the action for the page transitions.
        /// </summary>
        private void PageTransitionAction()
        {
            this.Invoke(new Action(() =>
            {
                ExanResultDetailForm resultForm = new ExanResultDetailForm();
                resultForm.Show();
                this.Close();
            }));
        }

        /// <summary>
        /// Handles the click event for the view detial button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void DoBtnViewDetailClick(object sender, EventArgs e)
        {
            pageTransitions = new Thread(PageTransitionAction);
            pageTransitions.Start();
        }

        /// <summary>
        /// Handles the click event for the close button.
        ///     Backs to main form.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        public override void DoLblOpreaCloseClick(object sender, EventArgs e)
        {
            Session.CurrentExam = null;
            Session.CurrentQuestionList = null;
            ControlUtils.reloadList();
            Session.formDictionary[Constants.FormKeyMain].Show();
            this.Close();
        }

        #endregion
    }
}