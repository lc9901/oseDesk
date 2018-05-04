using System;
using System.Drawing;
using System.Windows.Forms;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provides a custom header.
    /// </summary>
    public partial class CustomizeHead : UserControl
    {
        /// <summary>
        /// Represents the control icon.
        /// </summary>
        private bool icoSrc;

        /// <summary>
        /// Occurs when the control is clicked.
        /// </summary>
        public event EventHandler SortChanged;

        /// <summary>
        /// Initializes a new instance of the CustomizeHead class.
        /// </summary>
        public CustomizeHead()
        {
            InitializeComponent();

            this.lblContent.Location = Constants.CostomizeHeadContentLocation;
            this.Click += new EventHandler(CostumizeHeadClick);
            this.lblContent.Click += new EventHandler(CostumizeHeadClick);
            this.lblIoc.Click += new EventHandler(CostumizeHeadClick);
        }

        /// <summary>
        /// 
        /// Handles click event for current control.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void CostumizeHeadClick(object sender, EventArgs e)
        {
            if (icoSrc)
            {
                this.IcoSrc = false;
            }
            else
            {
                this.IcoSrc = true;
            }

            if (SortChanged != null)
            {
                this.SortChanged(this, e);
            }
            else
            { 
                // Nothing to do.
            }
        }

        #region Public Field
        /// <summary>
        /// Represents the control name.
        /// </summary>
        public string CulomeName { get; set; }

        /// <summary>
        /// Represents the control size.
        /// </summary>
        public Size ItemSize
        {
            set
            {
                this.Size = value;
            }
            get
            {
                return this.Size;
            }
        }

        /// <summary>
        /// Represents the control content.
        /// </summary>
        public string ContentText
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

        /// <summary>
        /// Represents the control icon location.
        /// </summary>
        public Point IcoLocation
        {
            set
            {
                this.lblIoc.Location = value;
            }
            get
            {
                return this.lblIoc.Location;
            }
        }

        /// <summary>
        /// Represents the control icon.
        /// </summary>
        public bool IcoSrc
        {
            set
            {
                this.icoSrc = value;
                if (value)
                {
                    this.lblIoc.Image = global::OnlineExamSystem.UI.Properties.Resources.ICN_Increase_10x15_png;
                }
                else
                {
                    this.lblIoc.Image = global::OnlineExamSystem.UI.Properties.Resources.ICN_Decrese_10x15_png;
                }
            }
            get
            {
                return icoSrc;
            }
        }

        /// <summary>
        /// Represents the sort status for this control
        /// </summary>
        public bool Selected
        {
            set 
            {
                this.lblIoc.Visible = value;
            }
            get
            {
                return this.lblIoc.Visible;
            }
        }

        #endregion
    }
}
