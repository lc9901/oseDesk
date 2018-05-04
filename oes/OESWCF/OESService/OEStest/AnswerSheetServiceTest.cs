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
    /// Provades a set testing method for AnswerSheetService class.
    /// </summary>
    [TestClass]
    public class AnswerSheetServiceTest
    {

        private Mock<IAnswerSheetDao> answerSheetDaoMock;
        private IAnswerSheetService answerSheetService;

        [TestInitialize]
        public void Initialize()
        {
            answerSheetDaoMock = new Mock<IAnswerSheetDao>(MockBehavior.Strict);
            answerSheetService = new AnswerSheetService(answerSheetDaoMock.Object);
        }

        [TestCleanup]
        public void CleanUp() 
        {
        }

        /// <summary>
        /// Calls the commit answer method with correct parameter.
        /// </summary>
        [TestMethod]
        public void AnswerSheetService_CommitAnswer_HappyTest()
        {
            AnswerSheet answerSheet = new AnswerSheet();
            answerSheet.Answer = TestConstants.TestAnswer;
            answerSheet.ExamId = TestConstants.TestExamId;
            answerSheet.QuestionId = TestConstants.TestQuestionId;
            answerSheet.RigthtAnswer = TestConstants.TestAnswer;
            answerSheet.UserId = TestConstants.TestUserId;

            answerSheetDaoMock.Setup(o => o.InsertAnswerToAnswerSheet(answerSheet));
            answerSheetService.CommitAnswer(answerSheet);
            answerSheetDaoMock.Verify(o => o.InsertAnswerToAnswerSheet(answerSheet), Times.AtLeastOnce());
        }

        /// <summary>
        /// Calls the commit answer method with null parameter.
        /// </summary>
        [TestMethod]
        public void AnswerSheetService_CommitAnswer_NullParameterTest()
        {
            AnswerSheet answerSheet = null;

            answerSheetDaoMock.Setup(o => o.InsertAnswerToAnswerSheet(answerSheet));
            try 
            {
                answerSheetService.CommitAnswer(answerSheet);
            }
            catch(Exception e)
            {
                FaultException ex = e as FaultException;
                Assert.IsNotNull(ex);
                Assert.IsNotNull(ex.Message);
            }
            answerSheetDaoMock.Verify(o => o.InsertAnswerToAnswerSheet(answerSheet), Times.Never());
        }

        /// <summary>
        /// Calls the commit answer method with parameter.
        /// </summary>
        [TestMethod]
        public void AnswerSheetService_CheckAnswerSheetList_HappyTest()
        {
            int userId = 1;
            int examId = 1;
            Collection<AnswerAndQuestionDetail> detial = new Collection<AnswerAndQuestionDetail>();
            Collection<AnswerAndQuestionDetail> resultDetial;
            AnswerAndQuestionDetail answerAndQuestionDetail = new AnswerAndQuestionDetail();
            detial.Add(answerAndQuestionDetail);

            answerSheetDaoMock.Setup(o => o.SelectAnswerSheetList(examId, userId)).Returns(detial);

            resultDetial = answerSheetService.CheckAnswerSheetList(examId, userId);
            Assert.AreEqual(resultDetial, detial);
        }

        /// <summary>
        /// Calls the commit answer method with exist exam id.
        /// </summary>
        [TestMethod]
        public void AnswerSheetService_CheckAnswerSheetList_ExamIdNotExistsTest()
        {
            int userId = 1;
            int examId = 1;
            Collection<AnswerAndQuestionDetail> detial = null;
            Collection<AnswerAndQuestionDetail> resultDetial;

            answerSheetDaoMock.Setup(o => o.SelectAnswerSheetList(examId, userId)).Returns(detial);

            resultDetial = answerSheetService.CheckAnswerSheetList(examId, userId);
            Assert.AreEqual(resultDetial, detial);
            Assert.IsNull(resultDetial);
        }
    }
}