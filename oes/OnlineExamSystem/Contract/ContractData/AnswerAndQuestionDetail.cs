using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Contract
{
    /// <summary>
    /// Represents a detail for the question.
    /// </summary>
    [DataContract]
    public class AnswerAndQuestionDetail
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

        /// <summary>
        /// Reqersents the description of the question.
        /// </summary>
        [DataMember]
        public String Description { get; set; }

        /// <summary>
        /// Repersents the option a of the question.
        /// </summary>
        [DataMember]
        public String OptionA { get; set; }

        /// <summary>
        /// Repersents the option b of the question.
        /// </summary>
        [DataMember]
        public String OptionB { get; set; }

        /// <summary>
        /// Repersents the option c of the question.
        /// </summary>
        [DataMember]
        public String OptionC { get; set; }

        /// <summary>
        /// Repersents the option d of the question.
        /// </summary>
        [DataMember]
        public String OptionD { get; set; }
    }
}
