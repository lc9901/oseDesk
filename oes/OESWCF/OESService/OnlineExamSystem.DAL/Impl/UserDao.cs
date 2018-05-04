using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Contract;

namespace OnlineExamSystem.DAL
{
    /// <see cref="Contract.IUserDao"/>
    public class UserDao :IUserDao
    {
        /// <see cref="Contract.IUserDao.FindUserByName"/>
        public User FindUserByName(string userName)
        {
            User user = null;
            string connectionStrings = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcLoginByUserName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserName, userName));

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            user = new User();

                            user.Id = dr.IsDBNull(0) ? Constants.DefaultId : dr.GetInt32(0);
                            user.UserName = dr.IsDBNull(1) ? Constants.DefaultStringEmpty : dr.GetString(1);
                            user.Password = dr.IsDBNull(2) ? Constants.DefaultStringEmpty : dr.GetString(2);
                            user.Gender = dr.IsDBNull(3) ? Constants.DefaultStringEmpty : dr.GetString(3);
                            user.RoleType = dr.IsDBNull(4) ? Constants.DefaultRoleType : dr.GetInt32(4);
                            user.Tel = dr.IsDBNull(5) ? Constants.DefaultStringEmpty : dr.GetString(5);
                            user.Email = dr.IsDBNull(6) ? Constants.DefaultStringEmpty : dr.GetString(6);
                            user.Avatar = dr.IsDBNull(7) ? Constants.DefaultStringEmpty : dr.GetString(7);
                            user.Description = dr.IsDBNull(8) ? Constants.DefaultStringEmpty : dr.GetString(8);
                            user.Address = dr.IsDBNull(9) ? Constants.DefaultStringEmpty : dr.GetString(9);
                            user.ChineseName = dr.IsDBNull(10) ? Constants.DefaultStringEmpty : dr.GetString(10);
                            user.CreateTime = dr.IsDBNull(11) ? DateTime.Now : dr.GetDateTime(11);
                            user.UpdateTime = dr.IsDBNull(12) ? DateTime.Now : dr.GetDateTime(12);
                            user.LastLoginTime = dr.IsDBNull(13) ? DateTime.Now : dr.GetDateTime(13);
                        }
                        else
                        { 
                            //Nothing to do.
                        }
                        return user;
                    }
                }
            }
        }

        /// <see cref="Contract.IUserDao.FindUserByName.UpdateLastLoginTime"/>
        public void UpdateLastLoginTime(int id)
        {
            string connectionStrings = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcModifyTheLoginTime, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(Constants.ParameterId, id));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterLastLoginTime, DateTime.Now));

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}