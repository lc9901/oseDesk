using System.Runtime.Serialization;
namespace Contract
{
    [DataContract]
    public class UserExam
    {
        /// <summary>
        /// Represents the id of the exam.
        /// </summary>
        [DataMember]
        public int Id { set; get; }

        /// <summary>
        /// Represents the id of the user.
        /// </summary>
        [DataMember]
        public int UserId { set; get; }

        /// <summary>
        /// Represents the id of the exam.
        /// </summary>
        [DataMember]
        public int ExamId { set; get; }

        /// <summary>
        /// Represents the status of the exam.
        /// </summary>
        [DataMember]
        public int ExamStatus { set; get; }

        /// <summary>
        /// Represents the score of the exam.
        /// </summary>
        [DataMember]
        public int Score { set; get; }

        /// <summary>
        /// Represents the right count of the exam.
        /// </summary>
        [DataMember]
        public int RightCount { set; get; }
    }
}