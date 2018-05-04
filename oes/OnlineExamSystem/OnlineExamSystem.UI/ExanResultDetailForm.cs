using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Contract;
using OnlineExamSystem.UI.CustomizeControl;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provades a exam result detail form.
    /// </summary>
    public partial class ExanResultDetailForm : BaseForm
    {

        #region Private Field
        /// <summary>
        /// Represents a answer sheet list.
        /// </summary>
        private Collection<AnswerAndQuestionDetail> answerList;
        #endregion

        #region Constractor method
        /// <summary>
        /// Initializes a new instance of the ExanResultDetailForm class.
        /// </summary>
        public ExanResultDetailForm()
        {
            InitializeComponent();
            this.InitData();
            this.InitEvent();
        }
        #endregion

        /// <summary>
        /// Initializes the data in this form.
        /// </summary>
        private void InitData()
        {
            this.InitDataWithExam();
            this.InitDataWithQuestion();
        }

        /// <summary>
        /// Initializes the data for the exam summary.
        /// </summary>
        private void InitDataWithQuestion()
        {
            using (ChannelFactory<IAnswerSheetService> factory = new ChannelFactory<IAnswerSheetService>(Constants.EndPointAnswerSheetService))
            {
                IAnswerSheetService answerSheetService = factory.CreateChannel();
                answerList = answerSheetService.CheckAnswerSheetList(Session.CurrentExam.Id, Session.CurrentUser.Id);
            }
            if (answerList != null)
            {
                CustomizeQuestionResultDetialItem customizeQuestionResultDetialItem;
                for (int i = 0; i < answerList.Count; i++) 
                {
                    customizeQuestionResultDetialItem = new CustomizeQuestionResultDetialItem();
                    customizeQuestionResultDetialItem.index = i + 1;
                    customizeQuestionResultDetialItem.Validity = (answerList[i].Answer.Equals(answerList[i].RigthtAnswer));
                    customizeQuestionResultDetialItem.StuSelect = answerList[i].Answer;
                    customizeQuestionResultDetialItem.Description = answerList[i].Description;
                    customizeQuestionResultDetialItem.Corrector = answerList[i].RigthtAnswer;
                    customizeQuestionResultDetialItem.OptionA = answerList[i].OptionA;
                    customizeQuestionResultDetialItem.OptionB = answerList[i].OptionB;
                    customizeQuestionResultDetialItem.OptionC = answerList[i].OptionC;
                    customizeQuestionResultDetialItem.OptionD = answerList[i].OptionD;
                    customizeQuestionResultDetialItem.Location = new Point(0, customizeQuestionResultDetialItem.Size.Height * i);
                    this.pnlQuestionDetailList.Controls.Add(customizeQuestionResultDetialItem);
                }
            }
            else
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Initializes the data for the question detail.
        /// </summary>
        private void InitDataWithExam()
        {
            using (ChannelFactory<IExamService> factory = new ChannelFactory<IExamService>(Constants.EndPointExamService))
            {
                IExamService examService = factory.CreateChannel();
                ExamListItem examListItem = examService.CheckOneExamResultDetail(Session.CurrentExam.Id, Session.CurrentUser.Id);
                if (examListItem != null)
                {
                    this.lblContentName.Text = examListItem.Name;
                    this.lblContentID.Text = examListItem.DisplayId;
                    this.lblContentEffEctive.Text = examListItem.EffectiveTime.ToString("yyyy-MM-dd hh:mm:ss");
                    this.lblContentDurition.Text = examListItem.Duration.ToString();
                    this.lblContentQuestion.Text = examListItem.QuestionQuantity.ToString();
                    this.lblContentTotalScore.Text = examListItem.TotleScore.ToString();
                    this.lblContentExamScore.Text = examListItem.ExamScore.ToString();
                    this.lblTitalRightCount.Text = examListItem.RightCoutn.ToString();
                    this.lblTitalExamScore.Text = examListItem.ExamScore.ToString();

                }
                else
                { 
                    // Nothing to do.
                }
            
            }

        }

        /// <summary>
        /// Initializes the events for this page.
        /// </summary>
        private void InitEvent()
        {
            this.pnlTitleControl.MouseDown += new MouseEventHandler(DoPnlTitleMouseDown);
            this.pnlTitleControl.MouseMove += new MouseEventHandler(DoPnlTitleMouseMove);
            this.pnlTitleControl.MouseUp += new MouseEventHandler(DoPnlTitleMouseUp);
            this.lblOpreaClose.Click += new EventHandler(DoLblOpreaCloseClick);
            this.lblOperaMin.Click += new EventHandler(DoLblOperaMinClick);
        }

        #region Form Control
        /// <summary>
        /// Handles a click event for the close button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void DoLblOpreaCloseClick(object sender, EventArgs e)
        {
            Session.CurrentExam = null;
            Session.CurrentQuestionList = null;
            ControlUtils.reloadList();
            Session.formDictionary[Constants.FormKeyMain].Show();

            this.Close();
            this.Dispose();
        }

        
        #endregion

    }
}