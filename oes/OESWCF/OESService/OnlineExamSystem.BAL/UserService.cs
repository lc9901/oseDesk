using System.ServiceModel;
using Contract;
using log4net;
using OnlineExamSystem.DAL;

namespace OnlineExamSystem.BAL
{
    /// <summary>
    /// Represents the implementation class of the user service.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// The userDao on which the class relies.
        /// </summary>
        IUserDao userDao;

        #region Constructor method
        public UserService(IUserDao userDao) {
            this.userDao = userDao;
        }

        public UserService() : this(new UserDao())
        {
        }
        #endregion

        /// <see cref="Contract.IUserService.Login"/>
        public User Login(string userName, string password)
        {
            User user = userDao.FindUserByName(userName);

            if (user == null)
            {
                var e = new UserNameNotExistsException();
                e.Message = Contract.Constants.ExceptionUserNotExists;
                FaultException<UserNameNotExistsException> ex = new FaultException<UserNameNotExistsException>(e, new FaultReason(e.Message));
                ILog log = LogManager.GetLogger(this.GetType());
                log.Warn(ex.Message);
                throw ex;
            }
            else
            { 
                // Nothing to do.
            }

            if (user.Password.Equals(password))
            {
                userDao.UpdateLastLoginTime(user.Id);
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}