using System.Collections.ObjectModel;
using OnlineExamSystem.DAL;
using Contract;
using System.ServiceModel;
using log4net;
using System.Threading;

namespace OnlineExamSystem.BAL
{
    /// <summary>
    /// Represents the implementation class of the exam service.
    /// </summary>
    public class ExamService : IExamService
    {
        //private ILog log = LogManager.GetLogger(GetType());
        /// <summary>
        /// The examDao on which the class relies.
        /// </summary>
        private IExamDao examDao;

        /// <summary>
        /// Represents a logger for this services.
        /// </summary>
        private ILog log;

        #region Contractor method.
        public ExamService(IExamDao examDao) 
        {
            this.examDao = examDao;
        }

        public ExamService() : this(new ExamDao()) 
        {
        }
        #endregion

        /// <see cref="Contract.IExamService.FindMyExamList"/>
        public Collection<ExamListItem> FindMyExamList(User user, ref Pagination pagination)
        {
            if (user == null || pagination == null)
            {
                var e = new ParametersException();
                e.Message = typeof(User).Name + Contract.Constants.OR + typeof(Pagination).Name + Contract.Constants.ExceptionParameterMessage;
                FaultException<ParametersException> ex = new FaultException<ParametersException>(e, new FaultReason(e.Message));
                log = LogManager.GetLogger(GetType());
                log.Warn(ex);
                throw ex;
            }
            else
            {
                // Nothing to do.
            }
            return examDao.QueryAllExamListByPagination(user, pagination);
        }

        /// <see cref="Contract.IExamService.CheckExamSummary"/>
        public Exam CheckExamSummary(int examId, int userId)
        {
            return examDao.QueryOneExamSummary(examId, userId);
        }

        /// <see cref="Contract.IExamService.CheckExamResultAbstract"/>
        public UserExam CheckExamResultAbstract(int examId, int userId)
        {
            return examDao.SelectOneExamResultAbstract(examId, userId);
        }

        /// <see cref="Contract.IExamService.CheckOneExamResultDetail"/>
        public ExamListItem CheckOneExamResultDetail(int examId, int userId)
        {
            return examDao.SelectOneExamResultDetail(examId, userId);
        }

        /// <see cref="Contract.IExamService.UpdateUseTime"/>
        public void UpdateUseTime(int examId, int userId, int intervalTime)
        {
            examDao.UpdateUsedTime(examId, userId, intervalTime);
        }

        /// <see cref="Contract.IExamService.CommitScore"/>
        public void CommitScore(int examId, int userId, int singleScore)
        {
            examDao.UpdateScore(examId, userId, singleScore);
        }

        /// <see cref="Contract.IExamService.SetExamStatusToFinish"/>
        public void SetExamStatusToFinish(int examId, int userId)
        {
            examDao.UpdateExamStatusToFinish(examId, userId);
        }

        /// <see cref="Contract.IExamService.GetExamNotice"/>
        public Collection<Exam> GetExamNotice(int userId, int topQuality, int diffTime)
        {
            return examDao.GetExamNotice(userId, topQuality, diffTime);
        }

        /// <see cref="Contract.IExamService.FindExamList"/>
        public Collection<Exam> FindExamList(ref Pagination pagination)
        {
            if (pagination == null)
            {
                var e = new ParametersException();
                e.Message =typeof(Pagination).Name + Contract.Constants.ExceptionParameterMessage;
                FaultException<ParametersException> ex = new FaultException<ParametersException>(e, new FaultReason(e.Message));
                log = LogManager.GetLogger(GetType());
                log.Warn(ex);
                throw ex;
            }
            else 
            {
                // Noting to do.
            }
            return examDao.QueryExamList(pagination);
        }
    }
}