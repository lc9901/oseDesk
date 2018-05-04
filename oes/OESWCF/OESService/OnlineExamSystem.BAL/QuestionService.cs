using System.Collections.ObjectModel;
using Contract;
using OnlineExamSystem.DAL;

namespace OnlineExamSystem.BAL
{
    /// <summary>
    /// Represents the implementation class of the question service.
    /// </summary>
    public class QuestionService : IQuestionService
    {
        /// <summary>
        /// The questionDao on which the class relies.
        /// </summary>
        IQuestionDao questionDao;

        #region Contractor method
        public QuestionService(IQuestionDao questionDao) 
        {
            this.questionDao = questionDao;
        }

        public QuestionService() : this(new QuestionDao())
        {
        }
        #endregion

        /// <see cref="Contract.IQuestionService.QueryCurrentExamQuestion"/>
        public Collection<Question> QueryCurrentExamQuestion(int examId)
        {
            Collection<Question> result = new Collection<Question>();
            result = questionDao.QueryQuestionListByExamId(examId);
            return result;
        }

        /// <see cref="Contract.IQuestionService.GetCurrentIndex"/>
        public int GetCurrentIndex(int examId, int userId)
        {
            int index = 0;
            index = questionDao.CheckCurrentIndexForExam(examId, userId);
            return index;

        }
    }
}
