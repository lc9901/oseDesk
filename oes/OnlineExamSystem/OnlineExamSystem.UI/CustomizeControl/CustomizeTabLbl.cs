using System;
using System.Drawing;
using System.Windows.Forms;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provides an function related to page display
    /// </summary>
    public partial class CustomizeTabLbl : UserControl
    {
        #region Private Field
        /// <summary>
        /// Represents the control selects the background color
        /// </summary>
        private readonly Color SelectedBackColor = Constants.SelectedBackColor;

        /// <summary>
        /// Represents the control normal background color
        /// </summary>
        private readonly Color NormalBackColor = Constants.NormalBackColor;

        /// <summary>
        /// Represents the control to select font colors
        /// </summary>
        private readonly Color SelectedFontColor = Constants.SelectedFontColor;

        /// <summary>
        /// Represents the control normal font color
        /// </summary>
        private readonly Color NormalFontColor = Constants.NormalFontColor;
        
        /// <summary>
        /// Represents the control status of selected. 
        ///     When selected, the value is true, otherwise the value is false
        /// </summary>
        private bool selected;
        #endregion

        /// <summary>
        /// Occurs when the control is clicked.
        /// </summary>
        public event EventHandler ConstomizeTabLblClick;

        /// <summary>
        /// Initializes a new instance of the CustomizeTabLbl class.
        /// </summary>
        public CustomizeTabLbl()
        {
            InitializeComponent();

            this.Click += new EventHandler(DoCostomizeTabLblClick);
            this.lblContent.Click += new EventHandler(DoCostomizeTabLblClick);
        }

        /// <summary>
        /// Handles the click event for go button.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void  DoCostomizeTabLblClick(object sender, EventArgs e)
        {
            if (!selected)
            {
                this.Selected = true;
                if (ConstomizeTabLblClick != null)
                {
                    ConstomizeTabLblClick(this, e);
                }
            }
        }

        #region Public Field
        /// <summary>
        /// Represents the control selected state, when selected, the value is true, otherwise the value is false.
        /// </summary>
        public bool Selected
        {
            set
            {
                if (value)
                {
                    this.lblContent.ForeColor = SelectedFontColor;
                    this.BackColor = SelectedBackColor;
                }
                else
                {
                    this.lblContent.ForeColor = NormalFontColor;
                    this.BackColor = NormalBackColor;
                }
                this.selected = value;
            }
            get
            {
                return this.selected;
            }
        
        }

        /// <summary>
        /// Represents the control content.
        /// </summary>
        public string Content
        {
            set
            {
                this.lblContent.Text = value;
            }
            get
            {
                return this.lblContent.Text;
            }
        }
        #endregion
    }
}