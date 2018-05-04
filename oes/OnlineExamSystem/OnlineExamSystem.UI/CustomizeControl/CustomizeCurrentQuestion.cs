using System;
using System.Windows.Forms;

namespace OnlineExamSystem.UI.CustomizeControl
{
    /// <summary>
    /// Provides a custom detail template for a problem.
    /// </summary>
    public partial class CustomizeCurrentQuestion : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the CustomizeCurrentQuestion class.
        /// </summary>
        public CustomizeCurrentQuestion()
        {
            InitializeComponent();
            this.rdoA.CheckedChanged += new EventHandler(DoRdoChecked);
            this.rdoB.CheckedChanged += new EventHandler(DoRdoChecked);
            this.rdoC.CheckedChanged += new EventHandler(DoRdoChecked);
            this.rdoD.CheckedChanged += new EventHandler(DoRdoChecked);
        }

        /// <summary>
        /// Occurs when any redio is selected.
        /// </summary>
        public event EventHandler SelectedEvent;

        /// <summary>
        /// Handles the click event for the redio button.
        /// </summary>
        /// <param name="sender">The sender is redio.</param>
        /// <param name="e"></param>
        private void DoRdoChecked(object sender, EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;

            if (rdo != null)
            {
                if (rdo == this.rdoA)
                { 
                    Answer = Constants.AnswerA;
                }
                else if (rdo == this.rdoB)
                {
                    Answer = Constants.AnswerB;
                }
                else if (rdo == this.rdoC)
                {
                    Answer = Constants.AnswerC;
                }
                else 
                {
                    Answer = Constants.AnswerD;
                }

                if (SelectedEvent != null)
                {
                    this.SelectedEvent(sender, e);
                }
            }
            else
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Represents current index.
        /// </summary>
        public int CurrentIndex
        {
            get 
            {
                return Convert.ToInt32(this.lblCurrentQuestionIndex.Text);
            }
            set 
            {
                this.lblCurrentQuestionIndex.Text = value.ToString();
            }
        }

        #region Public Field
        /// <summary>
        ///  Represents current question description.
        /// </summary>
        public string QuestionDescription
        {
            get
            {
                return this.lblQuestionDescription.Text;
            }
            set
            {
                this.lblQuestionDescription.Text = value;
            }
        }

        /// <summary>
        ///  Represents current question a option.
        /// </summary>
        public string OptionA
        {
            set
            {
                this.rdoA.Text = value;
            }
            get 
            {
                return this.rdoA.Text;
            }
        }

        /// <summary>
        ///  Represents current question a option.
        /// </summary>
        public string OptionB
        {
            set
            {
                this.rdoB.Text = value;
            }
            get
            {
                return this.rdoB.Text;
            }
        }

        /// <summary>
        ///  Represents current question a option.
        /// </summary>
        public string OptionC
        {
            set
            {
                this.rdoC.Text = value;
            }
            get
            {
                return this.rdoC.Text;
            }
        }

        /// <summary>
        ///  Represents current question a option.
        /// </summary>
        public string OptionD
        {
            set
            {
                this.rdoD.Text = value;
            }
            get
            {
                return this.rdoD.Text;
            }
        }

        /// <summary>
        /// Gets or sets the Answer value.
        /// </summary>
        public string Answer { set; get; }
        #endregion

        /// <summary>
        /// Rests the value of the redio.
        /// </summary>
        public void ReSetValue()
        {
            this.rdoA.Checked = false;
            this.rdoB.Checked = false;
            this.rdoC.Checked = false;
            this.rdoD.Checked = false;
        }
    }
}