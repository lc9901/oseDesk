using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OnlineExamSystem.UI.CustomizeControl
{
    /// <summary>
    /// Provades a item for teacher exam list.
    /// </summary>
    public partial class CustomizeTeacherExamListItem : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the CustomizeTeacherExamListItem class.
        /// </summary>
        public CustomizeTeacherExamListItem()
        {
            InitializeComponent();
        }

        #region Public field.
        /// <summary>
        /// Represents the index for the item.
        /// </summary>
        public int Index
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
        /// Represents the examination name for this item.
        /// </summary>
        public string ExamName
        {
            set
            {
                this.lblExamName.Text = value;
            }
            get
            {
                return this.lblExamName.Text;
            }
        }

        /// <summary>
        /// Represents the examination id for this item.
        /// </summary>
        public string ID
        {
            set
            {
                this.lblDisplayId.Text = value;
            }
            get
            {
                return this.lblDisplayId.Text;
            }
        }

        /// <summary>
        /// Represents the examination effective time.
        /// </summary>
        public DateTime EffectiveTime
        {
            set
            {
                this.lblEffectiveTime.Text = value.ToString("yyyy-MM-dd hh:mm:ss");
            }
            get
            {
                return Convert.ToDateTime(this.lblEffectiveTime.Text);
            }

        }

        /// <summary>
        /// Represents the question quantity for the examination.
        /// </summary>
        public int QuestionQuantity
        {
            set
            {
                this.lblQuestionQuantity.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblQuestionQuantity.Text);
            }
        }

        /// <summary>
        /// Represents the average score for the examination.
        /// </summary>
        public int AverageScore
        {
            set
            {
                this.lblAverageScore.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblAverageScore.Text);
            }
        }

        /// <summary>
        /// Represents the examination count for the examination.
        /// </summary>
        public int ExamineeCount
        {
            set
            {
                this.lblExamineeCount.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblAverageScore.Text);
            }
        }

        /// <summary>
        /// Represents the pass number for this examination.
        /// </summary>
        public int NumberQualified
        {
            set
            {
                this.lblPassCount.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblPassCount.Text);
            }
        }

        /// <summary>
        /// Represents the pass rate for this examination.
        /// </summary>
        public int PassRate
        {
            set
            {
                this.lblPassRate.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(this.lblPassRate.Text);
            }
        }
        #endregion
    }
}
