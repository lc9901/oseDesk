using System;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Contract;
using log4net;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Represents a testing form.
    /// </summary>
    public partial class TestingForm : BaseForm
    {
        #region Private Field

        /// <summary>
        /// Represents the current index in current exam.
        /// </summary>
        private int currentIndex;

        /// <summary>
        /// Represents the answer in the current exam..
        /// </summary>
        private AnswerSheet answerSheet = null;

        /// <summary>
        /// Represents the time in the current exam.
        /// </summary>
        private TimeSpan timeSpan;

        /// <summary>
        /// Represents a logger for this class.
        /// </summary>
        private ILog logger;

        /// <summary>
        /// Represents a thread for the commit answer.
        /// </summary>
        private Thread commitRequest;

        /// <summary>
        /// Represents the action of refresh remote used time.
        /// </summary>
        private Thread refreshRemoteUsedTime;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the TestingForm class.
        /// </summary>
        public TestingForm()
        {
            InitializeComponent();
            this.InitDate();
            this.InitEvent();
        }
        #endregion

        #region Initialize Method
        /// <summary>
        /// Initializes date in this page.
        /// </summary>
        private void InitDate()
        {
            this.currentIndex = Constants.DefaultCurrentIndex;

            using (ChannelFactory<IQuestionService> factory = new ChannelFactory<IQuestionService>(Constants.EndPointQuestionService))
            {
                IQuestionService questionService = factory.CreateChannel();
                this.currentIndex = questionService.GetCurrentIndex(Session.CurrentExam.Id,Session.CurrentUser.Id) + 1;
            }

            this.customizeExamStausBarUse.CurrentQuestionIndex = this.currentIndex;
            this.customCurrentQuestionUse.CurrentIndex = this.currentIndex;
            this.customizeExamStausBarUse.QuestionTotal = Session.CurrentQuestionList.Count;
            this.customCurrentQuestionUse.Answer = string.Empty;
            this.btnNextQuestion.Enabled = false;
            this.InitTimer();
        }

        /// <summary>
        /// Initializes remaining time in this page.
        /// </summary>
        private void InitTimer()
        {
            timeSpan = new TimeSpan(0, Session.CurrentExam.TimeLimit, 0);
            timeSpan = timeSpan.Subtract(new TimeSpan(0, 0, Session.CurrentExam.UseTime));

            if (timeSpan.TotalSeconds < 0)
            {
                timeSpan = new TimeSpan(0, 0, 0);
            }
            else
            { 
                // Noting to do.
            }

            this.customizeExamStausBarUse.RemainingTime = ControlUtils.SetTimeDisplay(timeSpan);

            this.customCurrentQuestionUse.QuestionDescription = Session.CurrentQuestionList[currentIndex - 1].Description;
            this.customCurrentQuestionUse.OptionA = Session.CurrentQuestionList[currentIndex - 1].OptionA;
            this.customCurrentQuestionUse.OptionB = Session.CurrentQuestionList[currentIndex - 1].OptionB;
            this.customCurrentQuestionUse.OptionC = Session.CurrentQuestionList[currentIndex - 1].OptionC;
            this.customCurrentQuestionUse.OptionD = Session.CurrentQuestionList[currentIndex - 1].OptionD;
        }

        /// <summary>
        /// Initializes event in this page.
        /// </summary>
        private void InitEvent()
        {
            this.pnlTitleControl.MouseDown += new MouseEventHandler(DoPnlTitleMouseDown);
            this.pnlTitleControl.MouseMove += new MouseEventHandler(DoPnlTitleMouseMove);
            this.pnlTitleControl.MouseUp += new MouseEventHandler(DoPnlTitleMouseUp);
            this.lblOpreaClose.Click += new EventHandler(DoLblOpreaCloseClick);
            this.lblOperaMin.Click += new EventHandler(DoLblOperaMinClick);
            this.lblOpreaMax.Click += new EventHandler(DoLblOpreaMaxClick);
            this.customCurrentQuestionUse.SelectedEvent += new EventHandler(DoCustomCurrentQuestionUseSelectedEvent);

            this.tmrTimer.Tick += new EventHandler(DoTmrTimerTick);
            this.btnNextQuestion.Click += new EventHandler(DoBtnNextQuestionClick);
        }

        
        #endregion

        #region Event Method

        /// <summary>
        /// Handles the click event for redio clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args</param>
        private void DoCustomCurrentQuestionUseSelectedEvent(object sender, EventArgs e)
        {
            this.btnNextQuestion.Enabled = true;
        }

        /// <summary>
        /// Handles the click event for the next question button.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">e</param>
        private void DoBtnNextQuestionClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.customCurrentQuestionUse.Answer))
            {
                answerSheet = new AnswerSheet();
                answerSheet.ExamId = Session.CurrentExam.Id;
                answerSheet.UserId = Session.CurrentUser.Id;
                answerSheet.QuestionId = Session.CurrentQuestionList[currentIndex - 1].Id;
                answerSheet.Answer = this.customCurrentQuestionUse.Answer;
                answerSheet.RigthtAnswer = Session.CurrentQuestionList[currentIndex - 1].Answer;

                if (answerSheet != null)
                {
                    commitRequest = new Thread(CommitAnswerAction);
                    commitRequest.Start();
                }
                else
                {
                    // Nothig to do.
                }

            }
            else
            {
                MessageBox.Show(Constants.ChoiseTip);
                return;
            }
        }

        /// <summary>
        /// Handles the time changed event for the timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoTmrTimerTick(object sender, EventArgs e)
        {
            double doubleSec = this.timeSpan.TotalSeconds;

            if (doubleSec <= 0)
            {
                this.tmrTimer.Enabled = false;
                this.SubmitWay(true);
            }
            else
            {
                if (doubleSec % Constants.IntervalTime == 0)
                {
                    refreshRemoteUsedTime = new Thread(RefreshUsedTime);
                    refreshRemoteUsedTime.Start();
                }

                TimeSpan timeSpanSub = new TimeSpan(0, 0, 1);
                timeSpan = timeSpan.Subtract(timeSpanSub);
                this.customizeExamStausBarUse.RemainingTime = ControlUtils.SetTimeDisplay(timeSpan);
            }
        }

        /// <summary>
        /// Handles the click event for the max button.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">e</param>
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
            this.tmrTimer.Enabled = false;
            Session.CurrentExam = null;
            Session.CurrentQuestionList = null;
            ControlUtils.reloadList();
            Session.formDictionary[Constants.FormKeyMain].Show();
            this.Close();
        }

        #endregion

        #region Accessory method
        /// <summary>
        /// Submits the exam.
        /// </summary>
        /// <param name="submitWay">The submitWay</param>
        private void SubmitWay(bool submitWay)
        {
            try
            {
                using (ChannelFactory<IExamService> factory = new ChannelFactory<IExamService>(Constants.EndPointExamService))
                {

                    IExamService examService = factory.CreateChannel();
                    examService.SetExamStatusToFinish(Session.CurrentExam.Id, Session.CurrentUser.Id);
                }

                ExamResultAbstractForm examResultAbstractForm = new ExamResultAbstractForm();
                examResultAbstractForm.TimeOut = submitWay;
                examResultAbstractForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                logger = LogManager.GetLogger(this.GetType());
                logger.Warn(ex);
            }

        }

        /// <summary>
        /// Refreshers the question.
        /// </summary>
        private void ReloadPage()
        {
            this.customCurrentQuestionUse.Answer = string.Empty;
            this.customCurrentQuestionUse.ReSetValue();

            this.customizeExamStausBarUse.CurrentQuestionIndex = this.currentIndex;
            this.customCurrentQuestionUse.CurrentIndex = this.currentIndex;
            this.customCurrentQuestionUse.QuestionDescription = Session.CurrentQuestionList[currentIndex - 1].Description;
            this.customCurrentQuestionUse.OptionA = Session.CurrentQuestionList[currentIndex - 1].OptionA;
            this.customCurrentQuestionUse.OptionB = Session.CurrentQuestionList[currentIndex - 1].OptionB;
            this.customCurrentQuestionUse.OptionC = Session.CurrentQuestionList[currentIndex - 1].OptionC;
            this.customCurrentQuestionUse.OptionD = Session.CurrentQuestionList[currentIndex - 1].OptionD;
            this.btnNextQuestion.Enabled = false;
        }

        /// <summary>
        /// Handles the action for refresh used time.
        /// </summary>
        private void RefreshUsedTime() 
        {
            using (ChannelFactory<IExamService> factory = new ChannelFactory<IExamService>(Constants.EndPointExamService))
            {
                try 
                {
                    IExamService examService = factory.CreateChannel();
                    examService.UpdateUseTime(Session.CurrentExam.Id, Session.CurrentUser.Id, Convert.ToInt32(Constants.IntervalTime));
                }
                catch(Exception ex)
                {
                    logger = LogManager.GetLogger(this.GetType());
                    logger.Warn(ex);
                }
                
            }
        }

        /// <summary>
        /// Actions for the commit.
        /// </summary>
        /// <param name="answerSheet"></param>
        private void CommitAnswerAction()
        {
            try
            {
                // Commits answer.
                using (ChannelFactory<IAnswerSheetService> factory = new ChannelFactory<IAnswerSheetService>(Constants.EndPointAnswerSheetService))
                {
                    IAnswerSheetService answerSheetService = factory.CreateChannel();
                    answerSheetService.CommitAnswer(answerSheet);

                }
            }
            catch(FaultException ex)
            {
                ILog logger = LogManager.GetLogger(this.GetType());
                logger.Warn(ex);
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(this.GetType());
                logger.Error(ex);
            }

            int singleScore = this.customCurrentQuestionUse.Answer.Equals(Session.CurrentQuestionList[currentIndex - 1].Answer) ? Session.CurrentExam.SingleQuestionScore : 0;

            // Update score.
            if (singleScore > 0)
            {
                try
                {
                    using (ChannelFactory<IExamService> factory = new ChannelFactory<IExamService>(Constants.EndPointExamService))
                    {
                        IExamService examService = factory.CreateChannel();
                        examService.CommitScore(Session.CurrentExam.Id, Session.CurrentUser.Id, singleScore);

                    }
                }
                catch (Exception ex)
                {
                    logger = LogManager.GetLogger(this.GetType());
                    logger.Warn(ex);
                }
            }
            else
            {
                // Nothing to do.
            }

            // Judge whether it is the last question.
            this.Invoke(new Action(() =>
            {
                if (this.currentIndex > Session.CurrentQuestionList.Count - 1)
                {
                    this.tmrTimer.Enabled = false;
                    this.SubmitWay(false);
                }
                else
                {
                    this.currentIndex++;
                    this.ReloadPage();
                }
                this.customCurrentQuestionUse.Answer = string.Empty;
            }));
        }
        #endregion
    }
}