using System;
using System.ServiceModel;
using System.Windows.Forms;
using Contract;
using System.Threading;
using log4net;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provades a form to display the examination summary.
    /// </summary>
    public partial class ExamSummaryForm : BaseForm
    {
        /// <summary>
        /// Represents a thread for data request.
        /// </summary>
        private Thread dataRequestThread;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the ExamSummaryForm class.
        /// </summary>
        public ExamSummaryForm()
        {
            InitializeComponent();

            this.InitWindowsControlEvent();
            this.InitData();
        }
        #endregion

        #region Event Method
        /// <summary>
        /// Initializes windows control event
        /// </summary>
        private void InitWindowsControlEvent()
        {
            this.pnlTitleControl.MouseDown += new MouseEventHandler(DoPnlTitleMouseDown);
            this.pnlTitleControl.MouseMove += new MouseEventHandler(DoPnlTitleMouseMove);
            this.pnlTitleControl.MouseUp += new MouseEventHandler(DoPnlTitleMouseUp);
            this.lblOpreaClose.Click += new EventHandler(DoLblOpreaCloseClick);
            this.lblOperaMin.Click += new EventHandler(DoLblOperaMinClick);
            this.lblOpreaMax.Click += new EventHandler(DoLblOpreaMaxClick);
            this.tmrShow.Tick += new EventHandler(DoTmrShowTick);
            this.btnReturn.Click += new EventHandler(DoBtnReturnClick);
            this.btnStart.Click += new EventHandler(DoBtnStartClick);
        }

        /// <summary>
        /// Handles the event for the timer.
        ///     The time display is changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void DoTmrShowTick(object sender, EventArgs e)
        {
            this.PageStatusController();
        }

        /// <summary>
        /// Handles the click event for the return button.
        ///     The window will be switched to main form.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void DoBtnReturnClick(object sender, EventArgs e)
        {
            this.DoLblOpreaCloseClick(sender, e);
        }

        /// <summary>
        /// Handles the click event for start button.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">e</param>
        private void DoBtnStartClick(object sender, EventArgs e)
        {
            dataRequestThread = new Thread(ExamStartAction);
            dataRequestThread.Start();
        }

        /// <summary>
        /// Represents the action for exam strat.
        /// </summary>
        private void ExamStartAction()
        {
            try
            {
                using (ChannelFactory<IQuestionService> factory = new ChannelFactory<IQuestionService>(Constants.EndPointQuestionService))
                {
                    IQuestionService questionService = factory.CreateChannel();
                    Session.CurrentQuestionList = questionService.QueryCurrentExamQuestion(Session.CurrentExam.Id);
                }

                this.Invoke(new Action(() =>
                {
                    if (Session.CurrentQuestionList.Count > 0)
                    {
                        TestingForm testing = new TestingForm();
                        this.tmrShow.Enabled = false;
                        testing.Show();
                        this.Close();
                    }
                    else 
                    {
                        MessageBox.Show(Constants.QuestionListError);
                    }
                }));
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(this.GetType());
                logger.Warn(ex);
            }
            
            
        }

        /// <summary>
        /// Handles the click event for max button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoLblOpreaMaxClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Handles the click event for close button.
        ///     Closes current windows and exit this project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void DoLblOpreaCloseClick(object sender, EventArgs e)
        {
            this.tmrShow.Enabled = false;
            Session.CurrentExam = null;
            Session.CurrentQuestionList = null;
            Session.formDictionary[Constants.FormKeyMain].Show();
            this.Close();
        }
        #endregion

        /// <summary>
        /// Initializes this data of page
        /// </summary>
        private void InitData()
        {
            this.lblContentName.Text = Session.CurrentExam.Name;
            this.lblContentID.Text = Session.CurrentExam.DiplayId;
            this.lblContentEffEctive.Text = Session.CurrentExam.EffectiveTime.ToString("yyyy-MM-dd hh:mm:ss");
            this.lblContentDurition.Text = Session.CurrentExam.TimeLimit.ToString();
            this.lblContentEndTime.Text = Session.CurrentExam.EffectiveTime.AddHours(Constants.ExamLong).ToString("yyyy-MM-dd hh:mm:ss");
            this.lblContentQuestion.Text = Session.CurrentExam.QuestionQuantity.ToString();
            this.lblContentTotal.Text = Session.CurrentExam.TotalScore.ToString();
            this.PageStatusController();
        }

        /// <summary>
        /// Initializes or sets the timer and start button status.
        /// </summary>
        private void PageStatusController()
        {
            TimeSpan startTime = Session.CurrentExam.EffectiveTime - DateTime.Now;

            if (startTime.TotalSeconds > (- Constants.ExamLong * Constants.UnitaryTatio))
            {
                this.tmrShow.Enabled = true;

                if (startTime.TotalSeconds > 0)
                {
                    this.lblTimeShow.Text = ControlUtils.SetTimeDisplay(startTime);
                }
                else
                {
                    this.lblTimeShow.Text = Constants.DefaultTimeShow;
                }
            }
            else
            {
                this.tmrShow.Enabled = false;
                this.lblTimeShow.Text = Constants.DefaultTimeShow;
            }

            if (startTime.TotalSeconds > 0 || startTime.TotalSeconds < (-Constants.ExamLong * Constants.UnitaryTatio))
            {
                this.btnStart.Enabled = false;
            }
            else
            {
                this.btnStart.Enabled = true;
            }
        }

    }
}