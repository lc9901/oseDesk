using System;
using System.Windows.Forms;

namespace OnlineExamSystem.UI.CustomizeControl
{
    /// <summary>
    /// Provades a question model for the exam result detail.
    /// </summary>
    public partial class CustomizeQuestionResultDetialItem : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the CustomizeQuestionResultDetialItem class.
        /// </summary>
        public CustomizeQuestionResultDetialItem()
        {
            InitializeComponent();
        }

        #region Public Field
        
        /// <summary>
        /// Represents the Validity.
        /// </summary>
        public bool Validity 
        {
            set
            {
                if (value)
                {
                    this.lblValidity.Image = global::OnlineExamSystem.UI.Properties.Resources.ICN_Right_15x15;
                }
                else
                {
                    this.lblValidity.Image = global::OnlineExamSystem.UI.Properties.Resources.ICN_Wrong_15x15;
                }
            }
        }

        /// <summary>
        /// Represents the index of the question.
        /// </summary>
        public int index
        {
            set
            {
                this.lblCurrentQuestionIndex.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblCurrentQuestionIndex.Text);
            }
        }
        
        /// <summary>
        /// Represents the Question description.
        /// </summary>
        public string Description
        {
            set
            {
                this.lblQuestionDescription.Text = value;
            }
        }

        /// <summary>
        /// Represents the student's answer.
        /// </summary>
        public string StuSelect
        {
            set
            {
                if(value.Equals(Constants.AnswerA))
                {
                    this.lblImgA.Image = global::OnlineExamSystem.UI.Properties.Resources.BTN_Radio_Selected_16x16_png;
                }
                else if(value.Equals(Constants.AnswerB))
                {
                    this.lblImgB.Image = global::OnlineExamSystem.UI.Properties.Resources.BTN_Radio_Selected_16x16_png;
                }
                 else if(value.Equals(Constants.AnswerC))
                {
                    this.lblImgC.Image = global::OnlineExamSystem.UI.Properties.Resources.BTN_Radio_Selected_16x16_png;
                }
                 else if(value.Equals(Constants.AnswerD))
                {
                    this.lblImgD.Image = global::OnlineExamSystem.UI.Properties.Resources.BTN_Radio_Selected_16x16_png;
                }
            }
        }

        /// <summary>
        /// Represents the corrector answer.
        /// </summary>
        public string Corrector
        {
        set
            {
                if(value.Equals(Constants.AnswerA))
                {
                    this.pnlOptBackA.BackColor = Constants.CorrectorBackColor;
                }
                else if(value.Equals(Constants.AnswerB))
                {
                    this.pnlOptBackB.BackColor = Constants.CorrectorBackColor;
                }
                 else if(value.Equals(Constants.AnswerC))
                {
                    this.pnlOptBackC.BackColor = Constants.CorrectorBackColor;
                }
                 else if(value.Equals(Constants.AnswerD))
                {
                    this.pnlOptBackD.BackColor = Constants.CorrectorBackColor;
                }
            }
        }

        /// <summary>
        /// Represents the description of option a.
        /// </summary>
        public string OptionA
        {
            set
            {
                this.lblOptADescription.Text = value;
            }
        }

        /// <summary>
        /// Represents the description of option b.
        /// </summary>
        public string OptionB 
        {
            set
            {
                this.lblOptBDescription.Text = value;
            }
        }

        /// <summary>
        /// Represents the description of option c.
        /// </summary>
        public string OptionC 
        {
            set
            {
                this.lblOptCDescription.Text = value;
            }
        }

        /// <summary>
        /// Represents the description of option d.
        /// </summary>
        public string OptionD 
        {
            set
            {
                this.lblOptDDescription.Text = value;
            }
        }
        #endregion
    }
}