using System.Collections.ObjectModel;
using Contract;

namespace OnlineExamSystem.DAL
{
    /// <summary>
    /// Represents an interface that is related to examination dao.
    /// </summary>
    public interface IExamDao
    {
        /// <summary>
        /// Queries exam list according to pagination.
        /// </summary>
        /// <param name="user">Current user information.</param>
        /// <param name="pagination">Current pagination config.</param>
        /// <returns></returns>
        Collection<ExamListItem> QueryAllExamListByPagination(User user, Pagination pagination);

        /// <summary>
        /// Queries the exam detail according to exam id.
        /// </summary>
        /// <param name="examId">examId</param>
        /// <returns></returns>
        Exam QueryOneExamSummary(int examId, int userId);

        /// <summary>
        /// Updates the score of the exam.
        /// </summary>
        /// <param name="examId">examId</param>
        /// <param name="userId">userId</param>
        /// <param name="singleScore"></param>
        void UpdateScore(int examId, int userId, int singleScore);

        /// <summary>
        /// Updates the status of the exam.
        /// </summary>
        /// <param name="examId">examId</param>
        /// <param name="userId">userId</param>
        void UpdateExamStatusToFinish(int examId, int userId);

        /// <summary>
        /// Selscts the reault abstract of exam.
        /// </summary>
        /// <param name="examId">examId</param>
        /// <param name="userId">userId</param>
        /// <returns>Contract.UserExam</returns>
        UserExam SelectOneExamResultAbstract(int examId, int userId);

        /// <summary>
        /// Selscts the reault details of exam.
        /// </summary>
        /// <param name="examId">examId</param>
        /// <param name="userId">userId</param>
        /// <returns>Contract.ExamListItem</returns>
        ExamListItem SelectOneExamResultDetail(int examId, int userId);

        /// <summary>
        /// Updates the used time of the exam.
        /// </summary>
        /// <param name="examId">examId</param>
        /// <param name="userId">userId</param>
        /// <param name="intervalTime">The unit is second.</param>
        void UpdateUsedTime(int examId, int userId, int intervalTime);

        /// <summary>
        /// Gets the notice list.
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="topQuality">topQuality</param>
        /// <param name="diffTime">diffTime</param>
        /// <returns></returns>
        Collection<Exam> GetExamNotice(int userId, int topQuality, int diffTime);

        /// <summary>
        /// Gets the exam list.
        /// </summary>
        /// <param name="pagination">The pagination.</param>
        /// <returns></returns>
        Collection<Exam> QueryExamList(Pagination pagination);
    }
}
