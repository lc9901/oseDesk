using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provates a block about the exam notice.
    /// </summary>
    public partial class CustomizeExamNoitc : UserControl
    {
        /// <summary>
        /// Occurs when the exam name is clicked.
        /// </summary>
        public event EventHandler NameClick;

        /// <summary>
        /// Initializes a new instance of the CustomizeExamNoitc class.
        /// </summary>
        public CustomizeExamNoitc()
        {
            InitializeComponent();
            this.lblExamname.Click += new EventHandler(lblExamname_Click);
        }

        /// <summary>
        /// Handles the click event for the lblexam label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblExamname_Click(object sender, EventArgs e)
        {
            if (NameClick != null)
            {
                this.NameClick(this, e);
            }
            else 
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Represents the index.
        /// </summary>
        public int Index 
        {
            get 
            {
                return int.Parse(this.lblIndex.Text);
            }
            set
            {
                this.lblIndex.Text = value.ToString();
            }
        }

        /// <summary>
        /// Represents the exam name.
        /// </summary>
        public string ExamName
        {
            get
            {
                return this.lblExamname.Text;
            }
            set
            {
                this.lblExamname.Text = value;
                this.lblExamname.Location = new Point(this.lblPlease.Size.Width + Constants.DateLocationX, this.lblExamname.Location.Y);
            }
        }

        /// <summary>
        /// Represents the date.
        /// </summary>
        public DateTime Time 
        {
            set
            {
                if (Thread.CurrentThread.CurrentCulture.ToString().Equals("zh"))
                {
                    this.lblTime.Text = Constants.ExamOnZH + value.ToString(Constants.DateFormatDate) + Constants.AtZH + value.ToString(Constants.DateFormatTime);
                }
                else
                {
                    this.lblTime.Text = Constants.ExamOn + value.ToString(Constants.DateFormatDate) + Constants.At + value.ToString(Constants.DateFormatTime);
                }
                this.lblTime.Location = new Point(this.lblPlease.Size.Width + Constants.DateLocationX + this.lblExamname.Size.Width, this.lblExamname.Location.Y);
                this.Size = new Size(this.lblPlease.Size.Width + Constants.DateLocationX + this.lblExamname.Size.Width + this.lblTime.Size.Width, this.Height);
            }
        }

        /// <summary>
        /// Represents the exam id for this notice.
        /// </summary>
        public int ExamId
        {
            set;
            get;
        }
    }
}