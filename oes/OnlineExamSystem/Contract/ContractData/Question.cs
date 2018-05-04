using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Contract
{
    /// <summary>
    /// Represents a question.
    /// </summary>
    [DataContract]
    public class Question
    {
        /// <summary>
        /// Represents the id of the question.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Repersents the status of the question.
        /// </summary>
        [DataMember]
        public QuestionEnum QuestionStatus { get; set; }

        /// <summary>
        /// Repersents the creator id of the question.
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// Reqersents the description of the question.
        /// </summary>
        [DataMember]
        public String Description { get; set; }

        /// <summary>
        /// Repersents the answer of the question.
        /// </summary>
        [DataMember]
        public String Answer { get; set; }

        /// <summary>
        /// Repersents the create time of the question.
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Repersents the update time of the question.
        /// </summary>
        [DataMember]
        public DateTime UpdateTime { get; set; }

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
