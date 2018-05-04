using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(UserNameNotExistsException))]
        User Login(string userName, string password);
    }
}
