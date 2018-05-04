using System.Runtime.Serialization;

namespace Contract
{
    /// <summary>
    /// Represents the constant configuration.
    /// </summary>
    [DataContract]
    public class Constants
    {
        /// <summary>
        /// Represents space for the current project, this field is readonly.
        /// </summary>
        [DataMember]
        public const string Blank = " ";

        /// <summary>
        /// Represents a exception tip.
        /// </summary>
        [DataMember]
        public const string ExceptionUserNotExists = "User name not exists.";

        /// <summary>
        /// Represents a part of exception tip.
        /// </summary>
        [DataMember]
        public const string ExceptionParameterMessage = " is null";

        /// <summary>
        /// Represents a part of exception tip.
        /// </summary>
        [DataMember]
        public const string OR = " or ";
    }
}
