using System.Collections.ObjectModel;
using Contract;

namespace OnlineExamSystem.DAL
{
    /// <summary>
    /// Represents an interface that is related to question dao.
    /// </summary>
    public interface IQuestionDao
    {
        /// <summary>
        /// Queries the exam list according to examination id.
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        Collection<Question> QueryQuestionListByExamId(int examId);

        /// <summary>
        /// Checks the current index according exam id and user id.
        /// </summary>
        /// <param name="examId">The examId</param>
        /// <param name="userId">The userId</param>
        /// <returns></returns>
        int CheckCurrentIndexForExam(int examId, int userId);
    }
}
