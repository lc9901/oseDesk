using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Contract
{
    /// <summary>
    /// Represents an interface that is related to examination business.
    /// </summary>
    [ServiceContract]
    public interface IExamService
    {
        /// <summary>
        /// Queries list by current user
        /// </summary>
        /// <param name="user">Current user</param>
        /// <param name="pagination">Current pagination</param>
        /// <returns>Exam list result</returns>
        [OperationContract]
        [FaultContract(typeof(ParametersException))]
        Collection<ExamListItem> FindMyExamList(User user, ref Pagination pagination);

        /// <summary>
        /// Queries examination details according to exam id.
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        [OperationContract]
        Exam CheckExamSummary(int examId, int userId);

        /// <summary>
        /// Commits the score to exam table.
        /// </summary>
        /// <param name="examId">The current exam id.</param>
        /// <param name="userId">The current user id.</param>
        /// <param name="singleScore">The score.</param>
        [OperationContract]
        void CommitScore(int examId, int userId, int singleScore);

        /// <summary>
        /// Set the status to finish for the exam.
        /// </summary>
        /// <param name="examId">The current exam id.</param>
        /// <param name="userId">The current user id.</param>
        [OperationContract]
        void SetExamStatusToFinish(int examId, int userId);

        /// <summary>
        /// Checks the examination result of abstract.
        /// </summary>
        /// <param name="examId">The current exam id.</param>
        /// <param name="userId">The current user id.</param>
        /// <returns>The examination result of abstract</returns>
        [OperationContract]
        UserExam CheckExamResultAbstract(int examId, int userId);

        /// <summary>
        /// Checks the examination result of detail.
        /// </summary>
        /// <param name="examId">The current exam id.</param>
        /// <param name="userId">The current user id.</param>
        /// <returns>The examination result of detail</returns>
        [OperationContract]
        ExamListItem CheckOneExamResultDetail(int examId, int userId);

        /// <summary>
        /// Update the use time.
        /// </summary>
        /// <param name="examId">The current exam id.</param>
        /// <param name="userId">The current user id.</param>
        /// <param name="intervalTime">The interval time.</param>
        [OperationContract]
        void UpdateUseTime(int examId, int userId, int intervalTime);

        /// <summary>
        /// Gets the notice list
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="topQuality">topQuality</param>
        /// <param name="diffTime">diffTime</param>
        /// <returns></returns>
        [OperationContract]
        Collection<Exam> GetExamNotice(int userId, int topQuality, int diffTime);

        /// <summary>
        /// Gets the exam list.
        /// </summary>
        /// <param name="pagination">The pagination</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ParametersException))]
        Collection<Exam> FindExamList(ref Pagination pagination);
    }
}
