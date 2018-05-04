using System.Windows.Forms;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provides a custom container.
    /// </summary>
    public partial class CustomizeTabItem : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the CustomizeTabItem class.
        /// </summary>
        public CustomizeTabItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Represents the control content
        /// </summary>
        public string ContentText
        {
            get
            {
                return this.lblContent.Text;
            }
            set
            {
                this.lblContent.Text = value;
            }
        }
    }
}