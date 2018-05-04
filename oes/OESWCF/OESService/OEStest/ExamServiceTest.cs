using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineExamSystem.BAL;
using OnlineExamSystem.DAL;

namespace OEStest
{
    /// <summary>
    /// Provades a set of method to test the exam service.
    /// </summary>
    [TestClass]
    public class ExamServiceTest
    {

        private Mock<IExamDao> examDaoMock;
        private ExamService examService;

        [TestInitialize]
        public void Initialize()
        {
            examDaoMock = new Mock<IExamDao>(MockBehavior.Strict);
            examService = new ExamService(examDaoMock.Object);
        }

        [TestCleanup]
        public void ClealUp()
        {
        }

        [TestMethod]
        public void ExamService_FindMyExamList_HappyTest()
        {
            User user = new User();
            user.Id = 1;
            Pagination pagination = new Pagination();
            pagination.CurrentPage = 1;
            pagination.ExamStatus = "all";
            pagination.PageSize = 10;

            Collection<ExamListItem> list = new Collection<ExamListItem>();
            Collection<ExamListItem> resultList = new Collection<ExamListItem>();

            ExamListItem item = new ExamListItem();
            list.Add(item);

            examDaoMock.Setup(o => o.QueryAllExamListByPagination(user, pagination)).Returns(list);

            resultList = examService.FindMyExamList(user, ref pagination);

            Assert.AreEqual(list, resultList);
        }

        [TestMethod]
        public void ExamService_FindMyExamList_UserNullTest()
        {
            User user = null;
            Pagination pagination = new Pagination();
            pagination.CurrentPage = 1;
            pagination.ExamStatus = "all";
            pagination.PageSize = 10;

            Collection<ExamListItem> list = new Collection<ExamListItem>();
            Collection<ExamListItem> resultList = new Collection<ExamListItem>();

            ExamListItem item = new ExamListItem();
            list.Add(item);
            examDaoMock.Setup(o => o.QueryAllExamListByPagination(user, pagination)).Returns(list);

            try 
            {
                resultList = examService.FindMyExamList(user, ref pagination);

            }
            catch (Exception e)
            {
                FaultException ex = e as FaultException;

                Assert.IsNotNull(ex);
            }

        }


        [TestMethod]
        public void ExamService_FindMyExamList_PaginationNullTest()
        {
            User user = new User();
            user.Id = 1;
            Pagination pagination = null;

            Collection<ExamListItem> list = new Collection<ExamListItem>();
            Collection<ExamListItem> resultList = new Collection<ExamListItem>();

            ExamListItem item = new ExamListItem();
            list.Add(item);
            examDaoMock.Setup(o => o.QueryAllExamListByPagination(user, pagination)).Returns(list);

            try
            {
                resultList = examService.FindMyExamList(user, ref pagination);

            }
            catch (Exception e)
            {
                FaultException ex = e as FaultException;

                Assert.IsNotNull(ex);
            }
        }


        [TestMethod]
        public void ExamService_FindMyExamList_AllParameterIsNullTest()
        {
            User user = null;
            Pagination pagination = null;

            Collection<ExamListItem> list = new Collection<ExamListItem>();
            Collection<ExamListItem> resultList = new Collection<ExamListItem>();

            ExamListItem item = new ExamListItem();
            list.Add(item);
            examDaoMock.Setup(o => o.QueryAllExamListByPagination(user, pagination)).Returns(list);

            try
            {
                resultList = examService.FindMyExamList(user, ref pagination);

            }
            catch (Exception e)
            {
                FaultException ex = e as FaultException;

                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void ExamService_CheckExamSummary_Test()
        {
            int examId = 1;
            int userId = 1;
            Exam exam = new Exam();
            Exam resultExam = new Exam();

            exam.CreateTime = DateTime.Now;
            exam.Description = TestConstants.TestDescription; ;
            exam.DiplayId = TestConstants.TestDisplay;
            exam.EffectiveTime = DateTime.Now;
            exam.ExamineeCount = 0;
            exam.Id = TestConstants.TestId;
            exam.Name = TestConstants.TestName;
            exam.PassCriteria = TestConstants.TestPass;
            exam.QuestionQuantity = TestConstants.TestQuantity;
            exam.SingleQuestionScore = TestConstants.TestSingle;
            exam.TimeLimit = TestConstants.TestTimeLimit;
            exam.TotalScore = TestConstants.TestTotalScore;
            exam.UserId = TestConstants.TestId;
            exam.UseTime = TestConstants.TestUseTime;

            examDaoMock.Setup(o => o.QueryOneExamSummary(examId, userId)).Returns(exam);

            resultExam = examService.CheckExamSummary(examId, userId);

            Assert.AreEqual(exam, resultExam);
        }

        [TestMethod]
        public void ExamService_CheckExamResultAbstrac_Test()
        {
            int examId = 1;
            int userId = 1;
            UserExam userExam = new UserExam();
            UserExam resultuserExam = new UserExam();

            userExam.Id = 1;
            examDaoMock.Setup(o => o.SelectOneExamResultAbstract(examId, userId)).Returns(userExam);

            resultuserExam = examService.CheckExamResultAbstract(examId, userId);

            Assert.AreEqual(userExam, resultuserExam);
        }


        [TestMethod]
        public void ExamService_CheckOneExamResultDetail_Test()
        {
            int examId = 1;
            int userId = 1;
            ExamListItem userExam = new ExamListItem();
            ExamListItem resultuserExam = new ExamListItem();

            userExam.Id = 1;
            examDaoMock.Setup(o => o.SelectOneExamResultDetail(examId, userId)).Returns(userExam);

            resultuserExam = examService.CheckOneExamResultDetail(examId, userId);

            Assert.AreEqual(userExam, resultuserExam);
        }

        [TestMethod]
        public void ExamService_UpdateUseTime_Test() 
        {
            int examId = 1;
            int userId = 1;
            int intervalTime = 30;
            examDaoMock.Setup(o => o.UpdateUsedTime(examId, userId, intervalTime));
            examService.UpdateUseTime(examId, userId, intervalTime);
            examDaoMock.Verify(o => o.UpdateUsedTime(examId, userId, intervalTime), Times.AtLeastOnce());
        }


        [TestMethod]
        public void ExamService_CommitScore_Test()
        {
            int examId = 1;
            int userId = 1;
            int singleScore = 10;

            examDaoMock.Setup(o => o.UpdateScore(examId, userId, singleScore));
            examService.CommitScore(examId, userId, singleScore);
            examDaoMock.Verify(o => o.UpdateScore(examId, userId, singleScore), Times.AtLeastOnce());
        }

        [TestMethod]
        public void ExamService_SetExamStatusToFinish_Test()
        {
            int examId = 1;
            int userId = 1;

            examDaoMock.Setup(o => o.UpdateExamStatusToFinish(examId, userId));
            examService.SetExamStatusToFinish(examId, userId);
            examDaoMock.Verify(o => o.UpdateExamStatusToFinish(examId, userId), Times.AtLeastOnce());
        }

        [TestMethod]
        public void ExamService_getExamNoticList_Test()
        {
            int userId = 1;
            int topQuality = 10;
            int diffTime = 60;
            Collection<Exam> noticeExam = new Collection<Exam>();
            Collection<Exam> resultNoticeExam;

            examDaoMock.Setup(o => o.GetExamNotice(userId,topQuality, diffTime)).Returns(noticeExam);
            resultNoticeExam = examService.GetExamNotice(userId, topQuality, diffTime);
            Assert.AreEqual(noticeExam, resultNoticeExam);
        }

        [TestMethod]
        public void ExamService_FindExamList_AllParameterIsNullTest()
        {
            Pagination pagination = null;

            Collection<Exam> list = new Collection<Exam>();
            Collection<Exam> resultList = new Collection<Exam>();

            Exam item = new Exam();
            list.Add(item);
            examDaoMock.Setup(o => o.QueryExamList(pagination)).Returns(list);

            try
            {
                resultList = examService.FindExamList(ref pagination);

            }
            catch (Exception e)
            {
                FaultException ex = e as FaultException;

                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void ExamService_FindExamList_HappyTest()
        {
            Pagination pagination = new Pagination();

            Collection<Exam> list = new Collection<Exam>();
            Collection<Exam> resultList = new Collection<Exam>();

            Exam item = new Exam();
            list.Add(item);
            examDaoMock.Setup(o => o.QueryExamList(pagination)).Returns(list);

            resultList = examService.FindExamList(ref pagination);
            Assert.AreEqual(list, resultList);
        }

    }
}