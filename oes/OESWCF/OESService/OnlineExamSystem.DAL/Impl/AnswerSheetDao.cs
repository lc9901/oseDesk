using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Contract;

namespace OnlineExamSystem.DAL
{
    /// <summary>
    /// <see cref="Contract.IAnswerSheetDao"/>
    /// </summary>
    public class AnswerSheetDao : IAnswerSheetDao
    {
        /// <see cref="Contract.IAnswerSheetDao.InsertAnswerToAnswerSheet"/>
        public void InsertAnswerToAnswerSheet(AnswerSheet answerSheet)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcCommitTheAnswer, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamId, answerSheet.ExamId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, answerSheet.UserId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterQuestionId, answerSheet.QuestionId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterAnswer, answerSheet.Answer));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterRightAnswer, answerSheet.RigthtAnswer));

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <see cref="Contract.IAnswerSheetDao.SelectAnswerSheetList"/>
        public Collection<AnswerAndQuestionDetail> SelectAnswerSheetList(int examId, int userId)
        {
            Collection<AnswerAndQuestionDetail> answerList = new Collection<AnswerAndQuestionDetail>();
            AnswerAndQuestionDetail answerSheet;
            string connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcSelectTheAnswerList, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamId, examId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, userId));

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            answerSheet = new AnswerAndQuestionDetail();
                            answerSheet.UserId = reader.IsDBNull(0) ? Constants.DefaultUserId : reader.GetInt32(0);
                            answerSheet.ExamId = reader.IsDBNull(1) ? Constants.DefaultExamId : reader.GetInt32(1);
                            answerSheet.QuestionId = reader.IsDBNull(2) ? Constants.DefaultQuestionId : reader.GetInt32(2);
                            answerSheet.Answer = reader.IsDBNull(3) ? Constants.DefaultAnswer : reader.GetString(3);
                            answerSheet.RigthtAnswer = reader.IsDBNull(4) ? Constants.DefaultAnswer : reader.GetString(4);
                            answerSheet.Description = reader.IsDBNull(5) ? Constants.DefaultDescription : reader.GetString(5);
                            answerSheet.OptionA = reader.IsDBNull(6) ? Constants.DefaultDescription : reader.GetString(6);
                            answerSheet.OptionB = reader.IsDBNull(7) ? Constants.DefaultDescription : reader.GetString(7);
                            answerSheet.OptionC = reader.IsDBNull(8) ? Constants.DefaultDescription : reader.GetString(8);
                            answerSheet.OptionD = reader.IsDBNull(9) ? Constants.DefaultDescription : reader.GetString(9);
                            
                            answerList.Add(answerSheet);
                        }
                    }
                }
            }
            return answerList;
        }
    }
}