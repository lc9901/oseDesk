using System.Collections.ObjectModel;
using Contract;

namespace OnlineExamSystem.DAL
{
    /// <summary>
    /// Represents the answer dao interface.
    /// </summary>
    public interface IAnswerSheetDao
    {
        /// <summary>
        /// Inserts the answer into the answer sheet table.
        /// </summary>
        /// <param name="answerSheet">answerSheet</param>
        void InsertAnswerToAnswerSheet(AnswerSheet answerSheet);

        /// <summary>
        /// Selects the list of answer.
        /// </summary>
        /// <param name="examId">examId</param>
        /// <param name="uesrId">userId</param>
        /// <returns>Answer list</returns>
        Collection<AnswerAndQuestionDetail> SelectAnswerSheetList(int examId, int userId);
    }
}
