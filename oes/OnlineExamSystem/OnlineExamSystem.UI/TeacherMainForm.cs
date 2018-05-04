using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Contract;
using System.ServiceModel;
using log4net;
using OnlineExamSystem.UI.CustomizeControl;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provades a teacher main form.
    /// </summary>
    public partial class TeacherMainForm : BaseForm
    {

        #region Private field
        /// <summary>
        /// Represents the pagination config.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Represents the exam list for current page.
        /// </summary>
        private Collection<Exam> examList;

        /// <summary>
        /// Represents a logger.
        /// </summary>
        private ILog logger;
        #endregion

        #region Constractor method.
        /// <summary>
        /// Initializes a new instance of the TeacherMainForm class.
        /// </summary>
        public TeacherMainForm()
        {
            InitializeComponent();
            this.InitPagination();

            this.InitBaseEvent();
            this.LoadList();

            this.InitPageBlock();
        }

        /// <summary>
        /// Initializes the exam list.
        /// </summary>
        private void LoadList()
        {
            this.InitListData();

            if (examList != null)
            {
                int i = 0;
                foreach(var examItem in examList)
                {
                    CustomizeTeacherExamListItem item = new CustomizeTeacherExamListItem();
                    item.Index = i + 1;
                    item.Name = examItem.Name;
                    item.ID = examItem.DiplayId;
                    item.EffectiveTime = examItem.EffectiveTime;
                    item.QuestionQuantity = examItem.QuestionQuantity;
                    item.AverageScore = examItem.AverageScore;
                    item.ExamineeCount = examItem.ExamineeCount;
                    item.NumberQualified = examItem.PassNumber;
                    item.PassRate = examItem.PassRate;
                    item.Location = new Point(0, item.Size.Height * i);
                    i++;
                    this.pnlExamListBody.Controls.Add(item);
                }
            }
            else
            {
                // Nothig to do.
            }
        }


        #endregion

        #region Private method
        /// <summary>
        /// Initializes the pagination config.
        /// </summary>
        private void InitPagination()
        {
            this.pagination.PageSize = Constants.DefaultPageSize;
            this.pagination.ExamStatus = Constants.ExaminationClassificationAll;
        }

        /// <summary>
        /// Adds event about page block control and data.
        /// </summary>
        private void InitPageBlock()
        {
            //dynamic allocation PageBlock
            this.costomizePagenaitionBlock = new OnlineExamSystem.UI.CustomizeControl.CustomizePagenaitionBlock(pagination);
            this.costomizePagenaitionBlock.Location = new System.Drawing.Point((this.Width - this.costomizePagenaitionBlock.Width) / 2, Constants.DefaultPageBlockLocationY);

            //dynamic allocation PageBlock
            this.pnlExamListBack.Controls.Add(this.costomizePagenaitionBlock);
            this.costomizePagenaitionBlock.PageNumberClicked += new EventHandler(DoCostomizePagenaitionBlockPageNumberClick);
            this.costomizePagenaitionBlock.PageSizeChanged += new EventHandler(DoCostomizePagenaitionBlockPageSizeChanged);
            this.costomizePagenaitionBlock.PagePervChanged += new EventHandler(DoCostomizePagenaitionBlockPagePervChanged);
            this.costomizePagenaitionBlock.PageNextChanged += new EventHandler(DoCostomizePagenaitionBlockPageNextChanged);
            this.costomizePagenaitionBlock.GoBtnClicked += new EventHandler(DoCostomizePagenaitionBlockGoClicked);
        }

        /// <summary>
        /// Initialize the list data for the current page.
        /// </summary>
        private void InitListData()
        {
            using (ChannelFactory<IExamService> factroy = new ChannelFactory<IExamService>(Constants.EndPointExamService))
            {
                try
                {
                    IExamService examService = factroy.CreateChannel();
                    examList = examService.FindExamList(ref pagination);
                }
                catch (FaultException ex)
                {
                    logger = LogManager.GetLogger(this.GetType());
                    logger.Warn(ex);
                }
                catch (Exception ex)
                {
                    logger = LogManager.GetLogger(this.GetType());
                    logger.Error(ex);
                }
            }

            
        }

        /// <summary>
        /// Resets location for page block.
        /// </summary>
        public void ResetPageBlock()
        {
            this.costomizePagenaitionBlock.Reload(pagination);
            this.costomizePagenaitionBlock.Location = new System.Drawing.Point((this.Width - this.costomizePagenaitionBlock.Width) / 2, Constants.DefaultPageBlockLocationY);
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
                this.pnlExamListBody.Controls.Clear();
                this.LoadList();
                this.ResetPageBlock();
            }
            else
            {
                //Nothing to do.
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
                this.pnlExamListBody.Controls.Clear();
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
                this.pnlExamListBody.Controls.Clear();
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
                this.pnlExamListBody.Controls.Clear();
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
                this.pnlExamListBody.Controls.Clear();
                this.LoadList();
                this.ResetPageBlock();
            }
            else
            {
                //Nothing to do.
            }
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




        /// <summary>
        /// Initalizes the event for windows control.
        /// </summary>
        private void InitBaseEvent()
        {
            this.lblLogout.Click += new EventHandler(DoLblLogoutClick);
            this.pnlTitleControl.MouseDown += new MouseEventHandler(DoPnlTitleMouseDown);
            this.pnlTitleControl.MouseMove += new MouseEventHandler(DoPnlTitleMouseMove);
            this.pnlTitleControl.MouseUp += new MouseEventHandler(DoPnlTitleMouseUp);
            this.lblOpreaClose.Click += new EventHandler(DoLblOpreaCloseClick);
            this.lblOperaMin.Click += new EventHandler(DoLblOperaMinClick);
        }

    }
}