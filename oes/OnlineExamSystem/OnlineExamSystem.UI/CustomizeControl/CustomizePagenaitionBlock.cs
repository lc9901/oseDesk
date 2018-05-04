using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using Contract;

namespace OnlineExamSystem.UI.CustomizeControl
{
    /// <summary>
    /// Provides a custom container for page flipping.
    /// </summary>
    public partial class CustomizePagenaitionBlock : UserControl
    {
        #region Public Field
        /// <summary>
        /// Represents page config in this control.
        /// </summary>
        public Pagination Paginations { get; set; }

        /// <summary>
        /// Occurs when the value of the page size property changes.
        /// </summary>
        public event EventHandler PageSizeChanged;

        /// <summary>
        /// Occurs when the lblPervPage control is clicked.
        /// </summary>
        public event EventHandler PagePervChanged;

        /// <summary>
        /// Occurs when the lblNextPage control is clicked.
        /// </summary>
        public event EventHandler PageNextChanged;

        /// <summary>
        /// Occurs when the go button is clicked.
        /// </summary>
        public event EventHandler GoBtnClicked;

        /// <summary>
        /// Occurs when the page number is clicked.
        /// </summary>
        public event EventHandler PageNumberClicked;

        /// <summary>
        /// Represents the Page size of current page.
        /// </summary>
        public int PageSize
        {
            set
            {
                this.cboPageSize.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.cboPageSize.SelectedItem);
            }
        }

        /// <summary>
        /// Represents destination page；
        /// </summary>
        public int TagPage
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.txtTagPage.Text);
                }
                catch (Exception)
                {
                    this.txtTagPage.Text = Constants.DefaultPage.ToString();
                    return Constants.DefaultPage;
                }
            }
        }

        /// <summary>
        /// Represents the text for the perpage label.
        /// </summary>
        public string perPageText 
        {
            set 
            {
                this.lblPerPage.Text = value;
            }
            get 
            {
                return this.lblPerPage.Text;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the CustomizePagenaitionBlock class.
        ///     This class needs a param of pagination.
        /// </summary>
        /// <param name="paginations">The pagination config.</param>
        public CustomizePagenaitionBlock(Pagination paginations)
        {
            this.Paginations = paginations;

            this.InitContent();
            InitializeComponent();
            this.PutLbl();
            this.SetDynamicControl();
            this.InitEvent();
        }

        /// <summary>
        /// Represents the page number lalel.
        /// </summary>
        private Collection<Label> pageNumberList = new Collection<Label>();

        /// <summary>
        /// Sets location of controls.
        /// </summary>
        private void SetDynamicControl()
        {

            this.pnlPageNumberPanel.Size = new Size((pageNumberList.Count + 1) * Constants.DefaultPageNumberSize.Width, this.pnlPageNumberPanel.Size.Height);

            // Sets the location of the panel of the reight page block.
            this.pnlRight.Location = new Point(Constants.DefaultPageBlockLeftPadding 
                     + this.pnlPageNumberPanel.Size.Width, this.pnlRight.Location.Y);

            // Sets the size of this control
            this.Size = new Size(Constants.DefaultPageBlockLeftPadding
                      + this.pnlPageNumberPanel.Size.Width + this.pnlRight.Width, this.Size.Height);
        }

        /// <summary>
        /// Initializes the contents.
        /// </summary>
        private void InitContent()
        {
            Label lblpage;

            if (Paginations.PageCount < Constants.PageDisplayLimit)
            {
                for (int i = 0; i < Paginations.PageCount; i++)
                {
                    lblpage = new Label();
                    lblpage.Text = Convert.ToString(i + 1);
                    this.SetsPageNumberLbl(lblpage, i);
                }
            }
            else 
            {
                if (Paginations.CurrentPage < Constants.PageNumberFive)
                {
                    for (int i = 0; i < Constants.PageNumberSeven; i++)
                    {
                        lblpage = new Label();

                        if (i == Constants.PageNumberFive)
                        {
                            lblpage.Text = Constants.PlaceholderOmit;
                        }
                        else if (i == Constants.PageNumberSix)
                        {
                            lblpage.Text = Convert.ToString(Paginations.PageCount);
                        }
                        else
                        {
                            lblpage.Text = Convert.ToString(i + 1);
                        }
                        this.SetsPageNumberLbl(lblpage, i);
                    }
                }
                else if (Paginations.PageCount - Paginations.CurrentPage < Constants.PageNumberFour)
                {
                    for (int i = 0; i < Constants.PageNumberSeven; i++)
                    {
                        lblpage = new Label();

                        if (i == 0)
                        {
                            lblpage.Text = Convert.ToString(1);
                        }
                        else if (i == 1)
                        {
                            lblpage.Text = Constants.PlaceholderOmit;
                        }
                        else
                        {
                            lblpage.Text = Convert.ToString(Paginations.PageCount - Constants.PageNumberSix + i);
                        }

                        this.SetsPageNumberLbl(lblpage, i);
                    }
                }
                else
                {
                    for (int i = 0; i < Constants.PageNumberSeven; i++)
                    {
                        lblpage = new Label();

                        if (i == 1 || i == Constants.PageNumberFive)
                        {
                            lblpage.Text = Constants.PlaceholderOmit;
                        }
                        else if (i == Constants.PageNumberSix)
                        {
                            lblpage.Text = Convert.ToString(Paginations.PageCount);
                        }
                        else if (i == Constants.PageNumberTow)
                        {
                            lblpage.Text = Convert.ToString(Paginations.CurrentPage - 1);
                        }
                        else if (i == Constants.PageNumberThree)
                        {
                            lblpage.Text = Convert.ToString(Paginations.CurrentPage);
                        }
                        else if (i == 0)
                        {
                            lblpage.Text = Convert.ToString(1);
                        }
                        else
                        {
                            lblpage.Text = Convert.ToString(Paginations.CurrentPage + 1);
                        }

                        this.SetsPageNumberLbl(lblpage, i);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lblpage">The label</param>
        /// <param name="i">index</param>
        private void SetsPageNumberLbl(Label lblpage, int i)
        {
            lblpage.Size = Constants.DefaultPageNumberSize;
            lblpage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblpage.Location = new Point(Constants.DefaultPageNumberIntervalX
                        + Constants.DefaultPageNumberSize.Width * i, Constants.DefaultPageNumberY);

            this.pageNumberList.Add(lblpage);
        }

        /// <summary>
        /// Puts the lbl of page number to panel.
        /// </summary>
        private void PutLbl()
        {
            int outNumber;
            for (int i = 0; i < this.pageNumberList.Count; i++)
            {
                if (Convert.ToString(Paginations.CurrentPage).Equals(pageNumberList[i].Text))
                {
                    pageNumberList[i].ForeColor = Constants.CurrentPageNumberColor;
                }
                else if (int.TryParse(pageNumberList[i].Text, out outNumber))
                {
                    pageNumberList[i].Click += new EventHandler(DoCustomizePagenaitionBlockClick);
                }
                else
                { 
                    // Nothing to do.
                }
                this.pnlPageNumberPanel.Controls.Add(this.pageNumberList[i]);
            }
        }

        #region Private Event
        /// <summary>
        /// Handles the click event for the page number lable.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">e</param>
        private void DoCustomizePagenaitionBlockClick(object sender, EventArgs e)
        {
            if (PageNumberClicked != null)
            {
                this.PageNumberClicked(sender, e);
            }
            else
            { 
                // Nothing to do.
            }
        }

        /// <summary>
        /// Initializes the event in this page.
        /// </summary>
        private void InitEvent()
        {
            this.cboPageSize.SelectedIndexChanged += new EventHandler(DoCboPageSizeSelectedIndexChanged);
            this.lblPervPage.Click += new EventHandler(DoLblPervPageClick);
            this.lblNextPage.Click += new EventHandler(DoLblNextPageClick);
            this.btnGo.Click += new EventHandler(DoBtnGoClick);
        }

        /// <summary>
        /// Handles click event for go button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">e</param>
        private void DoBtnGoClick(object sender, EventArgs e)
        {
            if (GoBtnClicked != null)
            {
                GoBtnClicked(sender, e);
            }
            else
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Handles click event for NextPage button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">e</param>
        private void DoLblNextPageClick(object sender, EventArgs e)
        {
            if (PageNextChanged != null)
            {
                PageNextChanged(sender, e);
            }
            else
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Handles click event for PervPage button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">e</param>
        private void DoLblPervPageClick(object sender, EventArgs e)
        {
            if (PagePervChanged != null)
            {
                PagePervChanged(sender, e);
            }
            else
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Handles index changed event for page size.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">e</param>
        private void DoCboPageSizeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (PageSizeChanged != null)
            {
                PageSizeChanged(sender, e);
            }
            else 
            {
                // Nothing to do.
            }
        }
        #endregion

        /// <summary>
        /// Resets the page number label.
        /// </summary>
        /// <param name="paginations">The pagination.</param>
        public void Reload(Pagination paginations)
        {
            this.Paginations = paginations;

            this.pageNumberList.Clear();
            this.InitContent();
            this.pnlPageNumberPanel.Controls.Clear();
            this.PutLbl();
            this.SetDynamicControl();
        }
    }
}