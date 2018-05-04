using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Contract;
using System.Threading;
using log4net;
using LocationTest;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Privades a main form
    /// </summary>
    public partial class StudentMainForm : BaseForm
    {
        #region Private Field
        /// <summary>
        /// Represents the exam status button list.
        /// </summary>
        private Collection<CustomizeTabLbl> listTab;

        /// <summary>
        /// Represents the pagination config.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Represents a exam list for current user.
        /// </summary>
        private Collection<ExamListItem> examList = new Collection<ExamListItem>();

        /// <summary>
        /// Represents a noitc list for current user.
        /// </summary>
        private Collection<Exam> noticeList = new Collection<Exam>();

        /// <summary>
        /// Represent a specific notice.
        /// </summary>
        private CustomizeExamNoitc noticeItem;

        /// <summary>
        /// Represents a logger.
        /// </summary>
        private ILog logger;

        /// <summary>
        /// Represents the current selected sort;
        /// </summary>
        private CustomizeHead customHeadSelected;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the MainForm class.
        /// </summary>
        public StudentMainForm()
        {
            InitializeComponent();


            this.InitPagination();
            this.InitListData();

            this.InitWindowsControlEvent();
            this.InitUserControl();
            
            this.InitExamStatusOption();
            this.InitExamListTitle();

            
            //First load list.
            this.LoadList();
            this.InitPageBlock();

            this.InitLblHome();
        }
        #endregion

        #region Public method

        /// <summary>
        /// Initializes the data for notice tag.
        /// </summary>
        public void InitNotice()
        {
            using(ChannelFactory<IExamService> factory = new ChannelFactory<IExamService>(Constants.EndPointExamService))
            {
                IExamService examService = factory.CreateChannel();
                noticeList = examService.GetExamNotice(Session.CurrentUser.Id, Constants.DefaultPageSize, Convert.ToInt32(Constants.ExamLong * Constants.TimeChangeOver));
            }

            if (noticeList.Count > 0)
            {
                this.lblThereIsNoExam.Visible = false;
                int index = 1;
                foreach (var item in noticeList) 
                {
                    noticeItem = new CustomizeExamNoitc();
                    noticeItem.ExamId = item.Id;
                    noticeItem.Location = new Point(Constants.NoticLocationX, Constants.NoticLocationY * (index - 1));
                    noticeItem.Index = index++;
                    noticeItem.ExamName = item.Name;
                    noticeItem.Time = item.EffectiveTime;
                    noticeItem.NameClick += new EventHandler(DoNoticeItemNameClick);
                    this.pnlNoticBack.Controls.Add(noticeItem);
                }
            }
            else 
            {
                this.lblThereIsNoExam.Visible = true;
            }

        }

        /// <summary>
        /// Resets location for page block.
        /// </summary>
        public void ResetPageBlock()
        {
            this.resources.ApplyResources(this.costomizePagenaitionBlock, Constants.CostomizePagenaitionBlock);
            this.costomizePagenaitionBlock.Reload(pagination);
            this.costomizePagenaitionBlock.Location = new System.Drawing.Point((this.Width - this.costomizePagenaitionBlock.Width) / 2, Constants.DefaultPageBlockLocationY);
        }

        /// <summary>
        /// Loads the exam list.
        /// </summary>
        public void LoadList()
        {
            this.InitListData();

            if (examList != null)
            {
                int i = 0;
                foreach (var examListItems in examList)
                {
                    CustomizeListItem listItem = new CustomizeListItem();
                    listItem.ItemIndex = i + 1;
                    listItem.ItemName = examListItems.Name;
                    listItem.ItemId = examListItems.DisplayId;
                    listItem.ItemEffectiveTime = examListItems.EffectiveTime;
                    listItem.ItemDuration = examListItems.Duration;
                    listItem.ItemPass = examListItems.Pass;
                    listItem.ItemScore = examListItems.ExamScore;
                    listItem.ItemTotalScore = examListItems.TotleScore;
                    listItem.ItemOperation = examListItems.Operation;
                    listItem.Tag = examListItems;
                    listItem.Location = new Point(0, listItem.Height * i);

                    if (examListItems.Operation == Constants.OperationStatus)
                    {
                        listItem.CheckExamDetail += new EventHandler(DoListItemCheckExamDetail);
                    }
                    else
                    { 
                        // Nothing to do.
                    }

                    listItem.NameCliked += new EventHandler(DolistItemNameCliked);

                    this.pnlListBody.Controls.Add(listItem);

                    i++;
                }
            }
            else
            {
                // Nothing to doing.
            }

        }
        #endregion

        #region Private Method
        /// <summary>
        /// Initializes the home lebal.
        /// </summary>
        private void InitLblHome()
        {
            this.pnlHomeBack.Visible = false;
            this.pnlAboutBack.Visible = false;
            this.InitNotice();
        }

        /// <summary>
        /// Initalizes the exam.
        /// </summary>
        private void InitListData()
        {
            using (ChannelFactory<IExamService> factory = new ChannelFactory<IExamService>(Constants.EndPointExamService))
            {
                IExamService examService = factory.CreateChannel();

                try 
                {
                    examList = examService.FindMyExamList(Session.CurrentUser, ref pagination);
                }
                catch (FaultException<ParametersException> ex)
                {
                    logger = LogManager.GetLogger(this.GetType());
                    logger.Warn(ex);
                }
                catch(Exception ex)
                {
                    logger = LogManager.GetLogger(this.GetType());
                    logger.Error(ex);
                }
                
            }
        }

        /// <summary>
        /// Initializes Windows Control Event.
        /// </summary>
        private void InitWindowsControlEvent()
        {
            this.pnlTitleControl.MouseDown += new MouseEventHandler(DoPnlTitleMouseDown);
            this.pnlTitleControl.MouseMove += new MouseEventHandler(DoPnlTitleMouseMove);
            this.pnlTitleControl.MouseUp += new MouseEventHandler(DoPnlTitleMouseUp);
            this.lblOpreaClose.Click += new EventHandler(DoLblOpreaCloseClick);
            this.lblOperaMin.Click += new EventHandler(DoLblOperaMinClick);
            this.lblChangeLanguage.Click += new EventHandler(DoLblChangeLanguageClick);
        }

        /// <summary>
        /// Handles the click event for set language button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoLblChangeLanguageClick(object sender, EventArgs e)
        {
            if (this.lblChangeLanguage.Text.Equals(Constants.CurrentLanguage))
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Constants.LanguageZh);
                SetLanguage.ReSetLanguage(Constants.LanguageZh, this, typeof(StudentMainForm));
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Constants.LangusgeEn);
                SetLanguage.ReSetLanguage(Constants.LangusgeEn, this, typeof(StudentMainForm));
            }
            this.pnlListBody.Controls.Clear();
            this.pnlNoticBack.Controls.Clear();
            this.InitNotice();
            this.LoadList();
            this.ResetPageBlock();
        }

        /// <summary>
        /// Initializes exam display condition, and config related event.
        /// </summary>
        private void InitExamStatusOption()
        {
            listTab = new Collection<CustomizeTabLbl>();
            listTab.Add(this.costomizeTabLblAll);
            listTab.Add(this.costomizeTabLblFinished);
            listTab.Add(this.costomizeTabLblUnfinished);

            this.costomizeTabLblAll.ConstomizeTabLblClick += new EventHandler(DoCostomizeTabLblClick);
            this.costomizeTabLblFinished.ConstomizeTabLblClick += new EventHandler(DoCostomizeTabLblClick);
            this.costomizeTabLblUnfinished.ConstomizeTabLblClick += new EventHandler(DoCostomizeTabLblClick);
        }

        /// <summary>
        /// Initializes Exam List Title Event and customHeadSelected.
        /// </summary>
        private void InitExamListTitle()
        {
            this.costumizeHeadName.SortChanged += new EventHandler(DoCostumizeHeadNameSortChanged);
            this.costumizeId.SortChanged += new EventHandler(DoCostumizeHeadNameSortChanged);
            this.costumizeEffectTime.SortChanged += new EventHandler(DoCostumizeHeadNameSortChanged);
            this.costumizePass.SortChanged += new EventHandler(DoCostumizeHeadNameSortChanged);
            this.costumizeTotal.SortChanged += new EventHandler(DoCostumizeHeadNameSortChanged);
            this.costumizeOpera.SortChanged += new EventHandler(DoCostumizeHeadNameSortChanged);

            //Initalizes default select sort.
            customHeadSelected = this.costumizeId;
            customHeadSelected.Selected = true;
        }

        /// <summary>
        /// Adds event about page block control and data.
        /// </summary>
        private void InitPageBlock()
        {
            //dynamic allocation PageBlock
            this.costomizePagenaitionBlock = new OnlineExamSystem.UI.CustomizeControl.CustomizePagenaitionBlock(pagination);
            this.costomizePagenaitionBlock.Location = new System.Drawing.Point((this.Width - this.costomizePagenaitionBlock.Width)/ 2, Constants.DefaultPageBlockLocationY);
            this.resources.ApplyResources(this.costomizePagenaitionBlock, Constants.CostomizePagenaitionBlock);

            //dynamic allocation PageBlock
            this.pnlContentBackBorder.Controls.Add(this.costomizePagenaitionBlock);
            this.costomizePagenaitionBlock.PageNumberClicked += new EventHandler(DoCostomizePagenaitionBlockPageNumberClick);
            this.costomizePagenaitionBlock.PageSizeChanged += new EventHandler(DoCostomizePagenaitionBlockPageSizeChanged);
            this.costomizePagenaitionBlock.PagePervChanged += new EventHandler(DoCostomizePagenaitionBlockPagePervChanged);
            this.costomizePagenaitionBlock.PageNextChanged += new EventHandler(DoCostomizePagenaitionBlockPageNextChanged);
            this.costomizePagenaitionBlock.GoBtnClicked += new EventHandler(DoCostomizePagenaitionBlockGoClicked);
        }

        /// <summary>
        /// Initializes the pagination config.
        /// </summary>
        private void InitPagination()
        {
            this.pagination.PageSize = Constants.DefaultPageSize;
            this.pagination.ExamStatus = Constants.ExaminationClassificationAll;
        }

        /// <summary>
        /// Initializes the user opreation event about information.
        /// </summary>
        private void InitUserControl()
        {
            this.lblLogout.Click += new EventHandler(DoLblLogoutClick);
            this.customizeUserInfo.ContentText = Session.CurrentUser.UserName;
            this.lblTabHome.Click += new EventHandler(DolblTabHomeOrExamClick);
            this.lblTabMyExam.Click += new EventHandler(DolblTabHomeOrExamClick);
            this.lblNotice.Click += new EventHandler(DoLblNoticeOrAboutClick);
            this.lblAbout.Click += new EventHandler(DoLblNoticeOrAboutClick);
        }

        /// <summary>
        /// Handles the click event for the notices.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void DoNoticeItemNameClick(object sender, EventArgs e)
        {
            CustomizeExamNoitc noticSender = sender as CustomizeExamNoitc;
            if (noticSender != null)
            {
                this.GoToExamSummaryFormAction(noticSender.ExamId);
            }
            else
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Handles click event for the HomeOrExamClick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void DolblTabHomeOrExamClick(object sender, EventArgs e)
        {
            Label clickTab = sender as Label;
            if (clickTab != null)
            {
                if (clickTab == this.lblTabHome)
                {
                    this.lblTabHome.BackColor = Constants.TabSelectedBackColor;
                    this.pnlListBody.Visible = false;

                    this.lblTabMyExam.BackColor = Constants.NormalBackColor;
                    this.pnlHomeBack.Visible = true;
                }
                else
                {
                    this.lblTabHome.BackColor = Constants.NormalBackColor;
                    this.pnlListBody.Visible = true;

                    this.lblTabMyExam.BackColor = Constants.TabSelectedBackColor;
                    this.pnlHomeBack.Visible = false;
                }
            }
            else
            {
                // Nothing to do.
            }


        }

        /// <summary>
        /// Handles click event for the notice label
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void DoLblNoticeOrAboutClick(object sender, EventArgs e)
        {
            Label clickTab = sender as Label;
            if (clickTab != null)
            {
                if (clickTab == this.lblNotice)
                {
                    this.lblNotice.BackColor = Constants.SelectedBackColor;
                    this.lblNotice.ForeColor = Constants.SelectedFontColor;

                    this.lblAbout.BackColor = Constants.NormalBackColor;
                    this.lblAbout.ForeColor = Constants.NormalFontColor;

                    this.pnlNoticBack.Visible = true;
                    this.pnlAboutBack.Visible = false;
                }
                else
                {
                    this.lblNotice.BackColor = Constants.NormalBackColor;
                    this.lblNotice.ForeColor = Constants.NormalFontColor;

                    this.lblAbout.BackColor = Constants.SelectedBackColor;
                    this.lblAbout.ForeColor = Constants.SelectedFontColor;

                    this.pnlNoticBack.Visible = false;
                    this.pnlAboutBack.Visible = true;
                }
            }
            else 
            {
                // Nothing to do.
            }

        }

        /// <summary>
        /// Handles the click event for the number button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void DoCostomizePagenaitionBlockPageNumberClick(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {
                this.pagination.CurrentPage = Convert.ToInt32(lbl.Text);
                this.pnlListBody.Controls.Clear();
                this.LoadList();
                this.ResetPageBlock();
            }
            else
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Handles the click event for the go button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoCostomizePagenaitionBlockGoClicked(object sender, EventArgs e)
        {
            if (!(this.pagination.CurrentPage == this.costomizePagenaitionBlock.TagPage))
            {
                this.pagination.CurrentPage = this.costomizePagenaitionBlock.TagPage;
                this.pnlListBody.Controls.Clear();
                this.LoadList();
                this.ResetPageBlock();
            }
            else 
            {
                //Nothing to do.
            }
        }

        /// <summary>
        /// Handles the current page index plus one event for this page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoCostomizePagenaitionBlockPageNextChanged(object sender, EventArgs e)
        {
            if (pagination.CurrentPage < pagination.PageCount)
            {
                pagination.CurrentPage += Constants.PageStep;
                this.pnlListBody.Controls.Clear();
                this.LoadList();
                this.ResetPageBlock();
            }
            else
            { 
                //Nothing to do.
            }
            
        }

        /// <summary>
        /// Handles the current page index minus one event for this page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoCostomizePagenaitionBlockPagePervChanged(object sender, EventArgs e)
        {
            if (pagination.CurrentPage > 1)
            {
                pagination.CurrentPage -= Constants.PageStep;
                this.pnlListBody.Controls.Clear();
                this.LoadList();
                this.ResetPageBlock();
            }
            else
            {
                //Nothing to do.
            }
        }

        /// <summary>
        /// Handles the click event for the list head.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoCostumizeHeadNameSortChanged(object sender, EventArgs e)
        {
            CustomizeHead current = sender as CustomizeHead;

            if (customHeadSelected != current)
            {
                customHeadSelected.Selected = false;
                customHeadSelected = current;
                customHeadSelected.Selected = true;
            }
            else 
            {
                // Nothing to do.
            }

            if (current != null)
            {
                pagination.SortColume = current.CulomeName;
                if (current.IcoSrc)
                {
                    pagination.SortWay = Constants.DESC;
                }
                else
                {
                    pagination.SortWay = Constants.ASC;
                }
            }
            else
            { 
                //Nothing to do.
            }

            this.pnlListBody.Controls.Clear();
            this.LoadList();
            this.ResetPageBlock();
        }

        /// <summary>
        /// Handles page size changed event for combox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoCostomizePagenaitionBlockPageSizeChanged(object sender, EventArgs e)
        {
            if (!(this.pagination.PageSize == this.costomizePagenaitionBlock.PageSize)) 
            {
                this.pagination.PageSize = this.costomizePagenaitionBlock.PageSize;
                this.pnlListBody.Controls.Clear();
                this.LoadList();
                this.ResetPageBlock();
            }
            else
            {
                //Nothing to do.
            }
            
        }

        /// <summary>
        /// Handles click event for exam name.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void DolistItemNameCliked(object sender, EventArgs e)
        {
            CustomizeListItem item = sender as CustomizeListItem;
            if (item != null) 
            {
                ExamListItem itemTag = item.Tag as ExamListItem;
                if (itemTag != null)
                {
                            if (itemTag.Operation == 0)
                            {
                                this.GoToExamSummaryForm(item);
                            }
                            else
                            {
                                this.GoToExamResultForm(item);
                            }
                }
                else
                { 
                    // Nothing to do.
                }
            }
            else
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Handles the click event for the exam button.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void DoListItemCheckExamDetail(object sender, EventArgs e)
        {
            CustomizeListItem listItem = sender as CustomizeListItem;

            if (listItem != null)
            {

                this.GoToExamSummaryForm(listItem);
            }
            else
            {
                //Nothing to do.
            }
        }

        /// <summary>
        /// Goes to the exam result form.
        /// </summary>
        /// <param name="item">The item</param>
        private void GoToExamResultForm(CustomizeListItem item)
        {

            ExamListItem exams = item.Tag as ExamListItem;

            using (ChannelFactory<IExamService> factory = new ChannelFactory<IExamService>(Constants.EndPointExamService))
            {
                IExamService examService = factory.CreateChannel();
                Session.CurrentExam = examService.CheckExamSummary(exams.Id, Session.CurrentUser.Id);
            }
            ExanResultDetailForm resultForm = new ExanResultDetailForm();
            resultForm.Show();
            Session.formDictionary[Constants.FormKeyMain].Hide();
        }

        /// <summary>
        /// Goes to the exam summary form.
        /// </summary>
        /// <param name="listItem">The listItem</param>
        private void GoToExamSummaryForm(CustomizeListItem listItem)
        {
            ExamListItem exams = listItem.Tag as ExamListItem;

            if (exams != null)
            {
                this.GoToExamSummaryFormAction(exams.Id);
            }
            else 
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Goes to the exam summary form with the action.
        /// </summary>
        /// <param name="examId"></param>
        private void GoToExamSummaryFormAction(int examId)
        {
            try 
            {
                using (ChannelFactory<IExamService> factory = new ChannelFactory<IExamService>(Constants.EndPointExamService))
                {
                    IExamService examService = factory.CreateChannel();
                    Session.CurrentExam = examService.CheckExamSummary(examId, Session.CurrentUser.Id);
                }

                ExamSummaryForm examSummary = new ExamSummaryForm();
                examSummary.Show();
                Session.formDictionary[Constants.FormKeyMain].Hide();
            }
            catch (Exception ex)
            {
                logger = LogManager.GetLogger(this.GetType());
                logger.Warn(ex);
            }
        }

        /// <summary>
        /// Sets tab select status about exam status.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void DoCostomizeTabLblClick(object sender, EventArgs e)
        {
            foreach (var item in listTab)
            {
                if (item != sender)
                {
                    item.Selected = false;
                }
                else
                { 
                    // Nothing to do.
                }
            }

            if (sender == this.costomizeTabLblAll)
            {
                pagination.ExamStatus = Constants.ExaminationClassificationAll;
            }
            else if (sender == this.costomizeTabLblUnfinished)
            {
                pagination.ExamStatus = Constants.ExaminationClassificationUnfinished;
            }
            else
            {
                pagination.ExamStatus = Constants.ExaminationClassificationFinished;
            }
            pagination.CurrentPage = Constants.DefaultCurrentPage;
            this.pnlListBody.Controls.Clear();
            this.LoadList();
            this.ResetPageBlock();
        }

        /// <summary>
        /// Handles the click event for the logout button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoLblLogoutClick(object sender, EventArgs e)
        {
            this.DoLblOpreaCloseClick(sender, e);
        }

        /// <summary>
        /// Override the method from the base form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void DoLblOpreaCloseClick(object sender, EventArgs e)
        {
            Session.CurrentUser = null;
            Session.formDictionary[Constants.FormKeyLogin].Show();
            Session.formDictionary[Constants.FormKeyMain].Close();
            Session.formDictionary.Remove(Constants.FormKeyMain);
        }
        #endregion

    }
}