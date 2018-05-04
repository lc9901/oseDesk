using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Contract;

namespace OnlineExamSystem.DAL
{
    /// <summary>
    /// <see cref="Contract.IExamDao"/>
    /// </summary>
    public class ExamDao : IExamDao
    {
        /// <see cref="Contract.IExamDao.QueryAllExamListByPagination"/>
        public Collection<ExamListItem> QueryAllExamListByPagination(User user, Pagination pagination)
        {
            Collection<ExamListItem> resultList = new Collection<ExamListItem>();
            ExamListItem examList;
            string connectionStrings = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcQueryExamListByRequirement, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, user.Id));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterPageSize, pagination.PageSize));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterCurrentPage, pagination.CurrentPage));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamStatus, pagination.ExamStatus.Trim().ToLower()));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterSortColume, pagination.SortColume));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterSortWay, pagination.SortWay));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        do
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (reader.FieldCount > 1)
                                    {
                                        examList = new ExamListItem();

                                        examList.Id = reader.IsDBNull(0) ? Constants.DefaultExamId : reader.GetInt32(0);
                                        examList.DisplayId = reader.IsDBNull(1) ? Constants.DefaultDiplayExamId : reader.GetString(1);
                                        examList.Name = reader.IsDBNull(2) ? Constants.DefaultExamName : reader.GetString(2);
                                        examList.EffectiveTime = reader.IsDBNull(3) ? DateTime.Now : reader.GetDateTime(3);
                                        examList.Duration = reader.IsDBNull(4) ? Constants.DefaultDuration : reader.GetInt32(4);
                                        examList.Pass = reader.IsDBNull(5) ? Constants.DefaultPassCriteria : reader.GetInt32(5);
                                        examList.TotleScore = reader.IsDBNull(6) ? Constants.DefaultTotleScore : reader.GetInt32(6);
                                        examList.ExamScore = reader.IsDBNull(7) ? Constants.DefaultExamScore : reader.GetInt32(7);
                                        examList.Operation = reader.IsDBNull(8) ? Constants.DefaultOperation : reader.GetInt32(8);

                                        resultList.Add(examList);
                                    }
                                    else
                                    {
                                        if (reader.GetName(0) == Constants.Culome)
                                        {
                                            pagination.TotalCount = reader.IsDBNull(0) ? Constants.DefaultTotalCount : reader.GetInt32(0);
                                        }
                                        else
                                        {
                                            //Nothing to do.
                                        }
                                    }
                                }
                            }
                        } while (reader.NextResult());
                    }
                }
            }
            return resultList;
        }

        /// <see cref="Contract.IExamDao.QueryOneExamSummary"/>
        public Exam QueryOneExamSummary(int examId, int userId)
        {
            Exam exam = null;
            string connectionStrings = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcQueryOneExamSummary, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamId, examId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, userId));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            exam = new Exam();
                            exam.Id = examId; 
                            exam.DiplayId = reader.IsDBNull(1) ? Constants.DefaultDiplayExamId : reader.GetString(1);
                            exam.UserId = reader.IsDBNull(2) ? Constants.DefaultDiplayUserId : reader.GetInt32(2);
                            exam.Name = reader.IsDBNull(3) ? Constants.DefaultExamName : reader.GetString(3);
                            exam.TotalScore = reader.IsDBNull(4) ? Constants.DefaultTotleScore : reader.GetInt32(4);
                            exam.QuestionQuantity = reader.IsDBNull(5) ? Constants.DefaultQuestionQuantity : reader.GetInt32(5);
                            exam.SingleQuestionScore = reader.IsDBNull(6) ? Constants.DefaultSingleQuestionScore : reader.GetInt32(6);
                            exam.CreateTime = reader.IsDBNull(7) ? DateTime.Now : reader.GetDateTime(7);
                            exam.Description = reader.IsDBNull(8) ? Constants.DefaultDescription :reader.GetString(8);
                            exam.EffectiveTime = reader.IsDBNull(9) ? DateTime.Now : reader.GetDateTime(9);
                            exam.PassCriteria = reader.IsDBNull(10) ? Constants.DefaultPassCriteria : reader.GetInt32(10);
                            exam.TimeLimit = reader.IsDBNull(11) ? Constants.DefaultTimeLimit : reader.GetInt32(11);
                            exam.ExamineeCount = reader.IsDBNull(12) ? Constants.DefaultExamineeCount : reader.GetInt32(12);
                            exam.UseTime = reader.IsDBNull(13) ? Constants.DefaultUseTime : reader.GetInt32(13);
                        }
                        else
                        { 
                            //Nothing to do.
                        }
                    }
                }
            }
            return exam;
        }

        /// <see cref="Contract.IExamDao.UpdateScore"/>
        public void UpdateScore(int examId, int userId, int singleScore)
        {
            string connectionStrings = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcUpdateScoreToExam, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamId, examId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, userId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterSingleScore, singleScore));

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <see cref="Contract.IExamDao.UpdateExamStatusToFinish"/>
        public void UpdateExamStatusToFinish(int examId, int userId)
        {
            String connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();
        
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand(Constants.ProcSetExamStatusToFinished, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamId, examId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, userId));

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <see cref="Contract.IExamDao.UpdateScore"/>
        public UserExam SelectOneExamResultAbstract(int examId, int userId)
        {
            UserExam userExam = null;

            String connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcQueryAbstractOfExam, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamId, examId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, userId));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userExam = new UserExam();
                            // Some code will be done.
                            userExam.Id = reader.IsDBNull(0) ? Constants.DefaultId : reader.GetInt32(0);
                            userExam.UserId = reader.IsDBNull(1) ? Constants.DefaultUserId : reader.GetInt32(1);
                            userExam.ExamId = reader.IsDBNull(2) ? Constants.DefaultExamId : reader.GetInt32(2);
                            userExam.ExamStatus = reader.IsDBNull(3) ? Constants.DefaultExamStatus : reader.GetInt32(3);
                            userExam.Score = reader.IsDBNull(4) ? Constants.DefaultExamScore : reader.GetInt32(4);
                            userExam.RightCount = reader.IsDBNull(5) ? Constants.DefaultRightCount : reader.GetInt32(5);
                        }
                    }
                }
            }
            return userExam;
        }

        /// <see cref="Contract.IExamDao.SelectOneExamResultDetail"/>
        public ExamListItem SelectOneExamResultDetail(int examId, int userId)
        {
            ExamListItem examListItem = null;

            string connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand(Constants.ProcSelectOneExamResultDetailByExamAndUserId, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamId, examId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, userId));

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            examListItem = new ExamListItem();

                            examListItem.Id = reader.IsDBNull(0) ? Constants.DefaultExamId : reader.GetInt32(0);
                            examListItem.Name = reader.IsDBNull(1) ? Constants.DefaultExamName : reader.GetString(1);
                            examListItem.DisplayId = reader.IsDBNull(2) ? Constants.DefaultDiplayExamId : reader.GetString(2);
                            examListItem.EffectiveTime = reader.IsDBNull(3) ? DateTime.Now : reader.GetDateTime(3);
                            examListItem.Duration = reader.IsDBNull(4) ? Constants.DefaultDuration : reader.GetInt32(4);
                            examListItem.QuestionQuantity = reader.IsDBNull(5) ? Constants.DefaultQuestionQuantity : reader.GetInt32(5);
                            examListItem.TotleScore = reader.IsDBNull(6) ? Constants.DefaultTotleScore : reader.GetInt32(6);
                            examListItem.ExamScore = reader.IsDBNull(7) ? Constants.DefaultExamScore : reader.GetInt32(7);
                            examListItem.RightCoutn = reader.IsDBNull(8) ? Constants.DefaultRightCount : reader.GetInt32(8);
                        }
                        else
                        {
                            // Nothing to do.
                        }
                    }
                }
            }
            return examListItem;
        }

        /// <see cref="Contract.IExamDao.UpdateUsedTime"/>
        public void UpdateUsedTime(int examId, int userId, int intervalTime)
        {
            String connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcUpdateExamUseTime, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(Constants.ParameterExamId, examId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, userId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterIntervalTime, intervalTime));

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <see cref="Contract.IExamDao.GetExamNotice"/>
        public Collection<Exam> GetExamNotice(int userId, int topQuality, int diffTime)
        {
            Collection<Exam> noticeList = new Collection<Exam>();
            Exam notice;
            string connectionStrings = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcGetExamNotice, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(Constants.ParameterUserId, userId));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterTopQuality, topQuality));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterDiffTime, diffTime));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                
                        while (reader.Read())
                        {
                            notice = new Exam();
                            notice.Id = reader.IsDBNull(0) ? Constants.DefaultExamId : reader.GetInt32(0);
                            notice.Name = reader.IsDBNull(1) ? Constants.DefaultExamName : reader.GetString(1);
                            notice.EffectiveTime = reader.IsDBNull(2) ? DateTime.Now : reader.GetDateTime(2);
                            noticeList.Add(notice);
                        }
                    }
                }
            }
            return noticeList;
        }

        /// <see cref="Contract.IExamDao.QueryExamList"/>
        public Collection<Exam> QueryExamList(Pagination pagination)
        {
            Collection<Exam> examList = new Collection<Exam>();
            Exam examItem;
            string connectionStrings = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString();

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Constants.ProcQueryExamListByTeacher, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(Constants.ParameterPageSize, pagination.PageSize));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterCurrentPage, pagination.CurrentPage));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterSortColume, pagination.SortColume));
                    command.Parameters.Add(new SqlParameter(Constants.ParameterSortWay, pagination.SortWay));
                    SqlParameter count = new SqlParameter(Constants.ParameterTotalCount, pagination.TotalCount);
                    count.Direction = ParameterDirection.Output;
                    command.Parameters.Add(count);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            examItem = new Exam();
                            examItem.Id = reader.IsDBNull(0) ? Constants.DefaultExamId : reader.GetInt32(0);
                            examItem.Name = reader.IsDBNull(1) ? Constants.DefaultExamName : reader.GetString(1);
                            examItem.DiplayId = reader.IsDBNull(2) ? Constants.DefaultDiplayExamId : reader.GetString(2);
                            examItem.EffectiveTime = reader.IsDBNull(3) ? DateTime.Now : reader.GetDateTime(3);
                            examItem.QuestionQuantity = reader.IsDBNull(4) ? Constants.DefaultQuestionQuantity : reader.GetInt32(4);
                            examItem.PassCriteria = reader.IsDBNull(5) ? Constants.DefaultPassCriteria : reader.GetInt32(5);
                            examItem.AverageScore = reader.IsDBNull(6) ? Constants.DefaultAverageScore : reader.GetInt32(6);
                            examItem.ExamineeCount = reader.IsDBNull(7) ? Constants.DefaultExamineeCount : reader.GetInt32(7);
                            examItem.PassNumber = reader.IsDBNull(8) ? Constants.DefaultPassNumber : reader.GetInt32(8);
                            examItem.PassRate = reader.IsDBNull(9) ? Constants.DefaultPassRate : reader.GetInt32(9);

                            examList.Add(examItem);
                        }
                    }
                    pagination.TotalCount = Convert.ToInt32(count.Value);
                }
            }
            return examList;
        }
    }
}