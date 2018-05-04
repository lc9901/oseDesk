using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Contract
{
    /// <summary>
    /// Represents an answer message.
    /// </summary>
    [DataContract]
    public class AnswerSheet
    {
        /// <summary>
        /// Represents the user id of the answer message
        /// </summary>
        [DataMember]
        public int UserId { set; get; }


        /// <summary>
        /// Represents the exam id of the answer message
        /// </summary>
        [DataMember]
        public int ExamId { set; get; }

        /// <summary>
        /// Represents the question id of the answer message
        /// </summary>
        [DataMember]
        public int QuestionId { set; get; }

        /// <summary>
        /// Represents the answer detail of the answer message
        /// </summary>
        [DataMember]
        public string Answer { set; get; }

        /// <summary>
        /// Represents the right answer detail of the answer message
        /// </summary>
        [DataMember]
        public string RigthtAnswer { get; set; }
    }
}