using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Contract
{
    /// <summary>
    /// Represents an interface thai is related to answer sheet service.
    /// </summary>
    [ServiceContract]
    public interface IAnswerSheetService
    {
        /// <summary>
        /// Submits the answer to the current question
        /// </summary>
        /// <param name="answerSheet"></param>
        [OperationContract]
        [FaultContract(typeof(ParametersException))]
        void CommitAnswer(AnswerSheet answerSheet);

        /// <summary>
        /// Gots the list of answer.
        /// </summary>
        /// <param name="examId">The examId.</param>
        /// <param name="uesrId">The userId</param>
        /// <returns>Contract.AnswerSheet</returns>
        [OperationContract]
        Collection<AnswerAndQuestionDetail> CheckAnswerSheetList(int examId, int userId);
    }
}
