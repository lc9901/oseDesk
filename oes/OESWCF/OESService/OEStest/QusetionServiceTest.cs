using System.Collections.ObjectModel;
using Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineExamSystem.BAL;
using OnlineExamSystem.DAL;

namespace OEStest
{
    [TestClass]
    public class QusetionServiceTest
    {
        /// <summary>
        /// Represents the mock object.
        /// </summary>
        private Mock<IQuestionDao> questionDaoMock;

        /// <summary>
        /// Represents the object for question service.
        /// </summary>
        private QuestionService questionService;

        /// <summary>
        /// Represents a method for initialization method.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            questionDaoMock = new Mock<IQuestionDao>(MockBehavior.Strict);
            questionService = new QuestionService(questionDaoMock.Object);
        }

        /// <summary>
        /// Represents a clean up method.
        /// </summary>
        [TestCleanup]
        public void CleanUp() 
        {
        }

        /// <summary>
        /// Calls the query list method with existing exam id.
        /// </summary>
        [TestMethod]
        public void QueryQuestionListByExamId_HappyTest()
        {
            int examId = TestConstants.ExamServiceExamId;
            Collection<Question> questionList = new Collection<Question>();
            Collection<Question> questionListResult;

            Question question;
            for (var i = 0; i < TestConstants.CollectionSize; i++) 
            {
                question = new Question();
                questionList.Add(question);
            }
            questionDaoMock.Setup(o => o.QueryQuestionListByExamId(examId)).Returns(questionList);

            questionListResult = questionService.QueryCurrentExamQuestion(examId);
            Assert.AreEqual(questionListResult.Count, questionList.Count);
        }

        /// <summary>
        /// Calls the query list method with the not exists examination id.
        /// </summary>
        [TestMethod]
        public void QueryQuestionListByExamId_NotExistExamIdTest()
        {
            int examId = TestConstants.ExamServiceExamIdNotExist;
            Collection<Question> questionList = new Collection<Question>();
            Collection<Question> questionListResult;
            questionDaoMock.Setup(o => o.QueryQuestionListByExamId(examId)).Returns(questionList);

            questionListResult = questionService.QueryCurrentExamQuestion(examId);
            Assert.AreEqual(questionListResult.Count, 0);
        }


        /// <summary>
        /// Calls the get current question index method with the not exists examination id.
        /// </summary>
        [TestMethod]
        public void GetCurrentIndex_NotExistExamIdTest()
        {
            int examId = 0;
            int userId = 1;
            questionDaoMock.Setup(o => o.CheckCurrentIndexForExam(examId, userId)).Returns(0);

            int resultIndex = questionService.GetCurrentIndex(examId, userId);
            Assert.AreEqual(resultIndex, 0);
        }

        /// <summary>
        /// Calls the get current question index method with the not exists examination id.
        /// </summary>
        [TestMethod]
        public void GetCurrentIndex_HappyTest()
        {
            int examId = 1;
            int userId = 1;
            questionDaoMock.Setup(o => o.CheckCurrentIndexForExam(examId, userId)).Returns(1);

            int resultIndex = questionService.GetCurrentIndex(examId, userId);
            Assert.AreEqual(resultIndex, 1);
        }
    }
}