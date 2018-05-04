using System.ServiceModel;

namespace Contract
{
    /// <summary>
    /// Represents a user service business interface 
    /// </summary>
    [ServiceContract]
    public interface IUserService
    {
        /// <summary>
        /// User login the system by user name and password
        ///     Exception reason: The user is null.
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns>The user</returns>
        [OperationContract]
        [FaultContract(typeof(UserNameNotExistsException))]
        User Login(string userName, string password);
    }
}