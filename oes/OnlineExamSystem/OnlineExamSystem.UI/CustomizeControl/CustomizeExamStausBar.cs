using System;
using System.Windows.Forms;

namespace OnlineExamSystem.UI.CustomizeControl
{
    /// <summary>
    /// Provides a custom test status bar.
    /// </summary>
    public partial class CustomizeExamStausBar : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the CustomizeExamStausBar class.
        /// </summary>
        public CustomizeExamStausBar()
        {
            InitializeComponent();
        }

        #region Public Field
        /// <summary>
        ///  Represents current question index
        /// </summary>
        public int CurrentQuestionIndex
        {
            get 
            {
                return Convert.ToInt32(this.lblTipQuestionIndex.Text);
            }
            set
            {
                this.lblTipQuestionIndex.Text = value.ToString();
            }
        }

        /// <summary>
        /// Represents current exam question total.
        /// </summary>
        public int QuestionTotal
        {
            get
            {
                return Convert.ToInt32(this.lblTotalCount.Text);
            }
            set
            {
                this.lblTotalCount.Text = value.ToString();
            }
        }

        /// <summary>
        /// Represents current exam remain time.
        /// </summary>
        public string RemainingTime
        {
            get
            {
                return this.lblTimrDisplay.Text;
            }
            set
            {
                this.lblTimrDisplay.Text = value;
            }
        }
        #endregion
    }
}