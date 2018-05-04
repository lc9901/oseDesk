using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Contract;
using System.Configuration;
using System;

namespace OnlineExamSystem.DAL
{
    /// <see cref="Contract.IQuestionDao"/>
    public class QuestionDao :IQuestionDao
    {
        /// <see cref="Contract.IQuestionDao.QueryQuestionListByExamId"/>
        public Collection<Question> QueryQuestionListByExamId(int examId)
        {
            Collection<Question> questionList = new Collection<Question>();
            Question question;

            string ConnectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcSelectQuestionOfCurrentExam, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamId, examId));

                    using(SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            question = new Question();
                            question.Id = reader.IsDBNull(0) ? Constants.DefaultId : reader.GetInt32(0);
                            question.Description = reader.IsDBNull(1) ? Constants.DefaultQuestionDescription : reader.GetString(1);
                            question.Answer = reader.IsDBNull(2) ? Constants.DefaultAnswer : reader.GetString(2);
                            question.OptionA = reader.IsDBNull(3) ? Constants.DefaultOption : reader.GetString(3);
                            question.OptionB = reader.IsDBNull(4) ? Constants.DefaultOption : reader.GetString(4);
                            question.OptionC = reader.IsDBNull(5) ? Constants.DefaultOption : reader.GetString(5);
                            question.OptionD = reader.IsDBNull(6) ? Constants.DefaultOption : reader.GetString(6);
                            questionList.Add(question);
                        }
                    }
                }
            }
            return questionList;
        }

        /// <see cref="Contract.IQuestionDao.CheckCurrentIndexForExam"/>
        public int CheckCurrentIndexForExam(int examId, int userId)
        {
            int index = Constants.DefaultIndex;
            string connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcCheckCurrentIndexForQuestion, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamId, examId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, userId));
                    SqlParameter count = command.Parameters.Add(new SqlParameter(Constants.ParameterIndex, 0));

                    count.Direction = System.Data.ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();
                    index = Convert.ToInt32(count.Value);
                }
            
            }
            return index;
        }
    }
}