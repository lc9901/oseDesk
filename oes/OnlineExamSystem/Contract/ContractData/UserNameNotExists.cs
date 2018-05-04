using System.Runtime.Serialization;

namespace Contract
{
    /// <summary>
    /// Represents the exception for the user name is not exists.
    /// </summary>
    [DataContract]
    public class UserNameNotExistsException
    {
        /// <summary>
        /// Represents the exception message.
        /// </summary>
        [DataMember]
        public string Message
        {
            set;
            get;
        }
    }
}
