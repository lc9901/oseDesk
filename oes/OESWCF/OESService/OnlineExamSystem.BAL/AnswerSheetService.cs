using System.Collections.ObjectModel;
using System.ServiceModel;
using Contract;
using log4net;
using OnlineExamSystem.DAL;

namespace OnlineExamSystem.BAL
{
    /// <summary>
    /// Represents the implementation class of the answer service.
    /// </summary>
    public class AnswerSheetService : IAnswerSheetService
    {
        /// <summary>
        /// The answerSheetDao on which the class relies.
        /// </summary>
        IAnswerSheetDao answerSheetDao;

        #region Contractor method
        public AnswerSheetService(IAnswerSheetDao answerSheetDao) 
        {
            this.answerSheetDao = answerSheetDao;
        }
        public AnswerSheetService() : this(new AnswerSheetDao())
        {
        }
        #endregion

        /// <see cref="Contract.IAnswerSheetService.CommitAnswer"/>
        public void CommitAnswer(AnswerSheet answerSheet)
        {
            if (answerSheet == null)
            {
                var e = new ParametersException();
                e.Message = typeof(AnswerSheet) + Contract.Constants.ExceptionParameterMessage;
                FaultException < ParametersException > ex = new FaultException<ParametersException>(e, new FaultReason(e.Message));
                ILog log = LogManager.GetLogger(this.GetType());
                log.Warn(ex);
                throw ex;
            }
            else
            {
                // Nothing to do.
            }
            answerSheetDao.InsertAnswerToAnswerSheet(answerSheet);
        }

        /// <see cref="Contract.IAnswerSheetService.CheckAnswerSheetList"/>
        public Collection<AnswerAndQuestionDetail> CheckAnswerSheetList(int examId, int userId)
        {
            return answerSheetDao.SelectAnswerSheetList(examId, userId);
        }
    }
}
