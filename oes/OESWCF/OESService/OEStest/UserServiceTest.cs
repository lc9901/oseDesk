using System.ServiceModel;
using Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineExamSystem.BAL;
using OnlineExamSystem.DAL;

namespace OEStest
{
    [TestClass]
    public class UserServiceTest
    {
        private UserService userService;
        private Mock<IUserDao> userDaoMock;
        private User testUser = new User();
        private User resultUser = new User();

        /// <summary>
        /// Initializes the object concerned.
        /// </summary>
        [TestInitialize]
        public void Initialize() 
        {
            userDaoMock = new Mock<IUserDao>(MockBehavior.Strict);
            userService = new UserService(userDaoMock.Object);

        }

        /// <summary>
        /// Cleans the mock object.
        /// </summary>
        [TestCleanup]
        public void CleanUp() 
        {
            userDaoMock.Verify();
        }

        /// <summary>
        /// Calls the Login method with normal parameter.
        /// </summary>
        [TestMethod]
        public void LoginTest_HappyPath()
        {
            string userName = TestConstants.UserServiceUserName;
            string password = TestConstants.UserServicePassword;

            testUser.UserName = userName;
            testUser.Password = password;


            userDaoMock.Setup(o => o.FindUserByName(userName)).Returns(testUser);
            userDaoMock.Setup(o => o.UpdateLastLoginTime(testUser.Id));

            resultUser = userService.Login(userName, password);

            Assert.AreEqual(resultUser.Password, testUser.Password);
        }

        /// <summary>
        /// Calls the login method with wrong password.
        /// </summary>
        [TestMethod]
        public void LoginTest_PasswordWrong()
        {
            string userName = TestConstants.UserServiceUserName;
            string password = TestConstants.UserServicePassword;
            string wrongPassword = TestConstants.UserServicePasswordWrong;

            testUser.UserName = userName;
            testUser.Password = password;


            userDaoMock.Setup(o => o.FindUserByName(userName)).Returns(testUser);
            userDaoMock.Setup(o => o.UpdateLastLoginTime(testUser.Id));

            resultUser = userService.Login(userName, wrongPassword);

            Assert.IsNull(resultUser);
        }

        /// <summary>
        /// Calls the login method with wrong username.
        /// </summary>
        [TestMethod]
        public void LoginTest_WrongUserName() 
        {
            string password = TestConstants.UserServicePassword;
            string wrongUserName = TestConstants.UserServiceUserNameWrong;

            testUser.UserName = wrongUserName;
            testUser.Password = password;

            userDaoMock.Setup(o => o.FindUserByName(testUser.UserName)).Returns(testUser = null);

            try
            {
                resultUser = userService.Login(wrongUserName, password);
            }
            catch (FaultException ex)
            {
                Assert.AreEqual(ex.Message, TestConstants.UserServiceUserNameIsNotExists);
            }
        }
    }
}
