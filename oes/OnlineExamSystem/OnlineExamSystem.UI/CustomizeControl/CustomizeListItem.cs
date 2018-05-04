using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provides a custom row of the list.
    /// </summary>
    public partial class CustomizeListItem : UserControl
    {
        /// <summary>
        /// Represents the control operation content display.
        /// </summary>
        private int itemOperation;

        /// <summary>
        /// Occurs when the operation control is clicked.
        /// </summary>
        public event EventHandler CheckExamDetail;

        /// <summary>
        /// Ocurrs when name is clicked.
        /// </summary>
        public event EventHandler NameCliked;

        /// <summary>
        /// Initializes a new instance of the CustomizeListItem class.
        /// </summary>
        public CustomizeListItem()
        {
            InitializeComponent();
        }

        #region Public Field
        /// <summary>
        /// Represents the control index
        /// </summary>
        public int ItemIndex
        {
            set
            {
                this.lblIndex.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblIndex.Text);
            }
        }

        /// <summary>
        /// Represents the item name
        /// </summary>
        public string ItemName
        {
            set
            {
                this.lblName.Text = value;
                this.lblName.Click += new EventHandler(DoLblNameClick);
            }
            get
            {
                return this.lblName.Text;
            }
        }

        /// <summary>
        /// Represents the item id
        /// </summary>
        public string ItemId
        {
            set
            {
                this.lblId.Text = value;
            }
            get
            {
                return this.lblId.Text;
            }
        }

        /// <summary>
        /// Represents the current entry valid time
        /// </summary>
        public DateTime ItemEffectiveTime
        {
            set
            {
                this.lblEffect.Text = value.ToString("yyyy-MM-dd hh:mm:ss");
            }
            get
            {
                return Convert.ToDateTime(this.lblEffect.Text);
            }
        }

        /// <summary>
        /// Represents the current valid time interval
        /// </summary>
        public int ItemDuration
        {
            set
            {
                this.lblDuration.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblDuration.Text);
            }
        }

        /// <summary>
        /// Represents the pass standard line
        /// </summary>
        public int ItemPass
        {
            set
            {
                this.lblPass.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblPass.Text);
            }
        }

        /// <summary>
        /// Represents the score
        /// </summary>
        public int ItemScore
        {
            set
            {
                this.lblScore.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblScore.Text);
            }
        }

        /// <summary>
        /// Represents the total score.
        /// </summary>
        public int ItemTotalScore
        {
            set
            {
                this.lblTotalScroe.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblTotalScroe.Text);
            }
        }

        /// <summary>
        /// Represents the control operation content display.
        /// </summary>
        public int ItemOperation
        {
            set
            {
                this.itemOperation = value;

                if (value == Constants.StatusDoIt)
                {
                    Font font = Constants.UnderLineFont;
                    this.lblOpera.ForeColor = Constants.FontClor;
                    this.lblOpera.Font = font;
                    this.lblOpera.Click += new EventHandler(DoLblOperaClick);
                    this.lblOpera.Cursor = System.Windows.Forms.Cursors.Hand;
                    if (Thread.CurrentThread.CurrentCulture.ToString().Equals("zh"))
                    {
                        this.lblOpera.Text = Constants.DoItZH;
                    }
                    else
                    {
                        this.lblOpera.Text = Constants.DoIt;
                    }
                }
                else if (value == Constants.StatusPass)
                {
                    if (Thread.CurrentThread.CurrentCulture.ToString().Equals("zh")) 
                    {
                        this.lblOpera.Text = Constants.PassZH;
                    }
                    else
                    {
                        this.lblOpera.Text = Constants.Pass;
                    }
                }
                else
                {
                    if (Thread.CurrentThread.CurrentCulture.ToString().Equals("zh"))
                    {
                        this.lblOpera.Text = Constants.NoPassZH;
                    }
                    else
                    {
                        this.lblOpera.Text = Constants.NoPass;
                    }
                }
            }
            get
            {
                return this.itemOperation;
            }
            
        }
        #endregion

        /// <summary>
        /// Handles click event for action field.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void DoLblOperaClick(object sender, EventArgs e)
        {
            if (this.CheckExamDetail != null)
            {
                this.CheckExamDetail(this, e);
            }
            else
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Handles the click event for name.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void DoLblNameClick(object sender, EventArgs e)
        {
            this.NameCliked(this, e);
        }
    }
}