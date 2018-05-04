using System.Runtime.Serialization;
namespace Contract
{
    /// <summary>
    /// Represents a exception for parameters.
    /// </summary>
    [DataContract]
    public class ParametersException
    {
        /// <summary>
        /// Represents a message of the exception.
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}
