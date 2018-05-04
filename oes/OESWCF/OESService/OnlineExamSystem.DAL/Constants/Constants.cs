namespace OnlineExamSystem.DAL
{
    /// <summary>
    /// On constants in the DAL section, the fields are read only in this class
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Represents the Connection StringsSection data for the current
        ///     application's default configuration.
        /// </summary>
        public const string ConnectionString = "sqlserver";

        #region The name of stored procedure
        public const string ProcLoginByUserName = "procLoginByUserName";
        public const string ProcModifyTheLoginTime = "procModifyTheLoginTime";
        public const string ProcQueryExamListByRequirement = "procQueryExamListByRequirement";
        public const string ProcQueryOneExamSummary = "procQueryOneExamSummary";
        public const string ProcSelectQuestionOfCurrentExam = "procSelectQuestionOfCurrentExam";
        public const string ProcCommitTheAnswer = "procCommitTheAnswer";
        public const string ProcCheckCurrentIndexForQuestion = "procCheckCurrentIndexForQuestion";
        public const string ProcUpdateScoreToExam = "procUpdateScoreToExam";
        public const string ProcSetExamStatusToFinished = "procSetExamStatusToFinished";
        public const string ProcSelectOneExamResultDetailByExamAndUserId = "procSelectOneExamResultDetailByExamAndUserId";
        public const string ProcSelectTheAnswerList = "procSelectTheAnswerList";
        public const string ProcQueryAbstractOfExam = "procQueryAbstractOfExam";
        public const string ProcUpdateExamUseTime = "procUpdateExamUseTime";
        public const string ProcGetExamNotice = "procGetExamNotice";
        public const string ProcQueryExamListByTeacher = "procQueryExamListByTeacher";

        #endregion

        #region Variable name
        public const string ParameterId = "@id";
        public const string ParameterUserName = "@userName";
        public const string ParameterLastLoginTime = "@lastLoginTime";
        public const string ParameterUserId = "@userId";
        public const string ParameterTotalCount = "@totalCount";
        public const string ParameterPageSize = "@pageSize";
        public const string ParameterCurrentPage = "@currentPage";
        public const string ParameterExamStatus = "@examStatus";
        public const string ParameterSortColume = "@sortColume";
        public const string ParameterSortWay = "@sortWay";
        public const string ParameterExamId = "@examId";
        public const string ParameterAnswer = "@answer";
        public const string ParameterQuestionId = "@questionId";
        public const string ParameterIndex = "@index";
        public const string ParameterSingleScore = "@singleScore";
        public const string ParameterRightAnswer = "@rightAnswer";
        public const string ParameterIntervalTime = "@intervalTime";
        public const string ParameterTopQuality = "@topQuality";
        public const string ParameterDiffTime = "@diffTime";

        #endregion

        #region Default parameter values
        public const string DefaultDiplayExamId = "E000001";
        public readonly static string DefaultStringEmpty = string.Empty;
        public const string DefaultExamName = "Test";
        public const string DefaultDescription = "Test is very important";
        public const string DefaultAnswer = "a";
        public const string DefaultOption = "There is no description.";
        public const string DefaultQuestionDescription = "There is no description.";
        public const string Culome = "totalCount";
        public const int DefaultTimeLimit = 60;
        public const int DefaultDuration = 60;
        public const int DefaultPassCriteria = 60;
        public const int DefaultTotleScore = 100;
        public const int DefaultExamScore = 0;
        public const int DefaultOperation = 0;
        public const int DefaultExamId = 1;
        public const int DefaultQuestionQuantity = 0;
        public const int DefaultPassRate = 0;
        public const int DefaultPassNumber = 0;
        public const int DefaultSingleQuestionScore = 0;
        public const int DefaultAverageScore = 0;
        public const int DefaultExamineeCount = 0;
        public const int DefaultTotalCount = 1;
        public const int DefaultDiplayUserId = 1;
        public const int DefaultId = 1;
        public const int DefaultRoleType = -1;
        public const int DefaultUserId = 1;
        public const int DefaultExamStatus = 2;
        public const int DefaultRightCount = 0;
        public const int DefaultQuestionId = 1;
        public const int DefaultUseTime = 0;
        public const int DefaultIndex = 0;

        #endregion
    }
}