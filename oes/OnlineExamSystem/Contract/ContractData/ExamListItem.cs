using System;
using System.Runtime.Serialization;

namespace Contract
{
    /// <summary>
    /// Represents the item of the exam list 
    /// </summary>
    [DataContract]
    public class ExamListItem
    {
        /// <summary>
        /// Represents the id of the exam.
        /// </summary>
        [DataMember]
        public int Id { set; get; }

        /// <summary>
        /// Represents the diplay id of the exam.
        /// </summary>
        [DataMember]
        public string DisplayId { set; get; }

        /// <summary>
        /// Represents the exam name of the exam.
        /// </summary>
        [DataMember]
        public string Name { set; get; }

        /// <summary>
        /// Represents the effective time of the exam.
        /// </summary>
        [DataMember]
        public DateTime EffectiveTime { set; get; }

        /// <summary>
        /// Represents the exam time limit.
        /// </summary>
        [DataMember]
        public int Duration { set; get; }

        /// <summary>
        /// Represents the criteria of the exam.
        /// </summary>
        [DataMember]
        public int Pass { set; get; }

        /// <summary>
        /// Represents the students's score of the exam.
        /// </summary>
        [DataMember]
        public int ExamScore { set; get; }

        /// <summary>
        /// Represents the total score of the exam.
        /// </summary>
        [DataMember]
        public int TotleScore { set; get; }

        /// <summary>
        /// Represents the operation that this exam can do.
        /// </summary>
        [DataMember]
        public int Operation { set; get; }

        /// <summary>
        /// Represents the right count in the exam.
        /// </summary>
        [DataMember]
        public int RightCoutn { set; get; }

        /// <summary>
        /// Represents the question count in the exam.
        /// </summary>
        [DataMember]
        public int QuestionQuantity { set; get; }
    }
}