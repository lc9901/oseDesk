using System.Collections.ObjectModel;
using Contract;
using System.Windows.Forms;
using System.Collections.Generic;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provides static variables.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Represents the user currently logged in
        /// </summary>
        public static User CurrentUser { set; get; }

        /// <summary>
        /// Represents the examination currently ongoing
        /// </summary>
        public static Exam CurrentExam { set; get; }

        /// <summary>
        /// Represents the question list of  examination currently ongoing
        /// </summary>
        public static Collection<Question> CurrentQuestionList { set; get; }

        /// <summary>
        /// Represents the current form collection.
        /// </summary>
        public static Dictionary<string, Form> formDictionary = new Dictionary<string, Form>(); 
    }
}