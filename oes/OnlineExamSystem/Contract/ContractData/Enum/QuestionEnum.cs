using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Contract
{
    /// <summary>
    /// Enumeration of question States.
    /// </summary>
    [DataContract]
    public enum QuestionEnum
    {
        /// <summary>
        ///  Represents a draft question.
        /// </summary>
        [EnumMember]
        DRAFT,

        /// <summary>
        ///  Represents a active question.
        /// </summary>
        [EnumMember]
        ACTIVE,

        /// <summary>
        ///  Represents a deletion question.
        /// </summary>
        [EnumMember]
        DELETE
    }
}
