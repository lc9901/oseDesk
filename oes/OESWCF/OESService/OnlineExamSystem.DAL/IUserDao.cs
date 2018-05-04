using Contract;

namespace OnlineExamSystem.DAL
{
    /// <summary>
    /// Represents a user dao business interface 
    /// </summary>
    public interface IUserDao
    {
        /// <summary>
        /// Find user by user name
        /// </summary>
        /// <param name="userName">userName</param>
        /// <returns></returns>
        User FindUserByName(string userName);

        /// <summary>
        /// Update login time in the last time by user id
        /// </summary>
        /// <param name="id">current userId</param>
        void UpdateLastLoginTime(int id);
    }
}