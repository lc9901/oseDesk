using System;
using System.Runtime.Serialization;

namespace Contract
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    [DataContract]
    public class User
    {
        /// <summary>
        /// Represents the id of the user.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Represents the user name of the user.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Represents the password of the user.
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// Represents the sex of the user.
        /// </summary>
        [DataMember]
        public string Gender { get; set; }

        /// <summary>
        /// Represents the role type of the user.
        /// </summary>
        [DataMember]
        public int RoleType { get; set; }

        /// <summary>
        /// Represents the telphone number of the user.
        /// </summary>
        [DataMember]
        public string Tel { get; set; }

        /// <summary>
        /// Represents the e-mail of the user.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Represents the photo of the user.
        /// </summary>
        [DataMember]
        public string Avatar { get; set; }

        /// <summary>
        /// Represents the description of the user.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Represents the address of the user.
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Represents the Chinese name of the user.
        /// </summary>
        [DataMember]
        public string ChineseName { get; set; }

        /// <summary>
        /// Represents the creation time of the user.
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Represents the update time of the user.
        /// </summary>
        [DataMember]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Represents the last logon time time of the user.
        /// </summary>
        [DataMember]
        public DateTime LastLoginTime { get; set; }
    }
}