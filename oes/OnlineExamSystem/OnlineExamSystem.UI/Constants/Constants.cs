using System.Drawing;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Represents the constant configuration in the UI section.
    /// </summary>
    public class Constants
    {
        #region Login form
        public const string LoginUserNameNotExistMassage = "User name is required.";
        public const string LoginUserNotExistMassage = "User is not exist.";
        public const string LoginPasswordNotExistMassage = "Password is required.";
        public const string LoginPasswordWrongMassage = "Password is wrong.";
        public const string LoginAllInformationNotExistMassage = "User name and password all required";
        public const string RememberUserName = "rememberUserName";
        public const string RememberPassword = "rememberPassword";
        #endregion

        #region Main form
        public const string DoIt = "Do it";
        public const string Pass = "Pass";
        public const string NoPass = "No pass";

        public const string ASC = " ASC ";
        public const string DESC = " DESC ";

        public const int StatusDoIt = 0;
        public const int StatusNoPass = 1;
        public const int StatusPass = 2;
        public const int OperationStatus = 0;
        public const double ExamLong = 4;
        public const double TimeChangeOver = 60;


        public const int DefaultCurrentPage = 1;
        public const string ExaminationClassificationAll = "all";
        public const string ExaminationClassificationUnfinished = "unfinished";
        public const string ExaminationClassificationFinished = "finished";
        public const int PageStep = 1;
        public const int DefaultPageSize = 10;
        public readonly static Color TabSelectedBackColor = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
        public const string NoticeTip = "There is no exam need to take :)";
        public const string CurrentLanguage = "中文";
        public const string LanguageZh = "zh";
        public const string LangusgeEn = "en";
        public const string CostomizePagenaitionBlock = "costomizePagenaitionBlock";
        
        #endregion

        #region Exam summary form
        public const string DefaultTimeShow = "00:00:00";
        public const double UnitaryTatio = 3600;
        public const string QuestionListError = "Question bank has a error, Please try again at later!";
        #endregion

        #region Customize control

        public readonly static Color SelectedBackColor = Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
        public readonly static Color NormalBackColor = System.Drawing.Color.White;
        public readonly static Color SelectedFontColor = System.Drawing.Color.White;
        public readonly static Color NormalFontColor = Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));

        public readonly static Point CostomizeHeadContentLocation = new Point(10, 10);

        public const string AnswerA = "a";
        public const string AnswerB = "b";
        public const string AnswerC = "c";
        public const string AnswerD = "d";


        public readonly static Font UnderLineFont = new Font("Arial", 9, FontStyle.Underline);
        public readonly static Color FontClor = Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));

        public const string DateFormatDate = "yyyy-MM-dd ";
        public const string DateFormatTime = "hh:mm";

        public const string ExamOn = "exam on ";
        public const string At = " at ";
        public const int DateLocationX = 30;

        public const int NoticLocationX = 10;
        public const int NoticLocationY = 50;
        public const string DoItZH = "开始考试";
        public const string PassZH = "通过";
        public const string NoPassZH = "没通过";
        public const string ExamOnZH = "考试时间是";
        public const string AtZH = " ";
        #endregion

        #region WCF end point
        public const string EndPointUserService = "userservice";
        public const string EndPointExamService = "examservice";
        public const string EndPointAnswerSheetService = "answersheetservice";
        public const string EndPointQuestionService = "questionservice";
        #endregion

        #region WinControl
        public const string PlaceholderTimeDisplay = "0";
        public const string BlankCharacterTimeDisplay = ":";
        public const int Boundary = 10;
        #endregion

        #region TestingForm
        public const string ChoiseTip = "Please choise a option";
        public const int DefaultCurrentIndex = 1;
        #endregion

        #region Exam result form
        public readonly static Color CorrectorBackColor = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
        public const double IntervalTime = 30;
        #endregion

        #region Page block
        public readonly static Size DefaultPageNumberSize = new Size(25, 15);

        public const int DefaultPageNumberY = 4;
        public const int DefaultPageNumberIntervalX = 4;
        public const int DefaultPageNumberStepX = 20;
        public const int DefaultPageBlockLeftPadding = 40;
        public const int DefaultPageBlockLocationY = 450;
        public const int DefaultPage = 1;
        public const int PageNumberTow = 2;
        public const int PageNumberThree = 3;
        public const int PageNumberFour = 4;
        public const int PageNumberFive = 5;
        public const int PageNumberSix = 6;
        public const int PageNumberSeven = 7;
        public const int PageDisplayLimit = 8;
        public const string PlaceholderOmit = "...";

        public readonly static Color CurrentPageNumberColor = Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
        #endregion

        #region Form key
        public const string FormKeyLogin = "LoginForm";
        public const string FormKeyMain = "MainForm";
        public const string FormKeyExamSummary = "ExamSummaryForm";
        public const string FormKeyExamResultDetail = "ExamResultDetailForm";
        public const string FormKeyTesting = "TestingForm";
        public const string FormKeyExamResultAbstract = "ExamResultAbstract";

        #endregion





        public const string ErrorTips = "Service erroe, please try again later.";
    }
}