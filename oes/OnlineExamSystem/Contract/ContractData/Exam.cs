using System;
using System.Runtime.Serialization;

namespace Contract
{
    /// <summary>
    /// Represents a exam details.
    /// </summary>
    [DataContract]
    public class Exam
    {
        /// <summary>
        /// Represents the id of the exam.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Represents the diplay id of the exam.
        /// </summary>
        [DataMember]
        public string DiplayId { get; set; }

        /// <summary>
        /// Represents the user id of the exam.
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// Represents the exam name of the exam.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Represents the total score of the exam.
        /// </summary>
        [DataMember]
        public int TotalScore { get; set; }

        /// <summary>
        /// Represents the question quantity of the exam.
        /// </summary>
        [DataMember]
        public int QuestionQuantity { get; set; }

        /// <summary>
        /// Represents the score for each question in the exam.
        /// </summary>
        [DataMember]
        public int SingleQuestionScore { get; set; }

        /// <summary>
        /// Represents the creation time of the exam.
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Represents the description in the exam.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Represents the effective time of the exam.
        /// </summary>
        [DataMember]
        public DateTime EffectiveTime { get; set; }

        /// <summary>
        /// Represents the criteria of the exam.
        /// </summary>
        [DataMember]
        public int PassCriteria { get; set; }

        /// <summary>
        /// Represents the exam time limit.
        /// </summary>
        [DataMember]
        public int TimeLimit { get; set; }

        /// <summary>
        /// Represents the number of times an exam takes place.
        /// </summary>
        [DataMember]
        public int ExamineeCount { get; set; }

        /// <summary>
        /// Represents the used time in the exam.
        /// </summary>
        [DataMember]
        public int UseTime { get; set; }

        /// <summary>
        /// Represents the average score of the exam.
        /// </summary>
        [DataMember]
        public int AverageScore { get; set; }

        /// <summary>
        /// Represents the pass rate of the exam.
        /// </summary>
        [DataMember]
        public int PassRate { get; set; }

        /// <summary>
        /// Represents the pass number of the exam.
        /// </summary>
        [DataMember]
        public int PassNumber { get; set; }
    }
}