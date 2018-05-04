using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Contract
{
    /// <summary>
    /// Represents an interface that is related to question business.
    /// </summary>
    [ServiceContract]
    public interface IQuestionService
    {
        /// <summary>
        /// Queries question list of current exam.
        /// </summary>
        /// <param name="examId">examId</param>
        /// <returns></returns>
        [OperationContract]
        Collection<Question> QueryCurrentExamQuestion(int examId);

        /// <summary>
        /// Gets the index of the current question.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int GetCurrentIndex(int examId, int userId);
    }
}
