
using System.ServiceModel;
using Contract;
namespace OnlineExamSystem.UI.Utils
{
    public class EndPointUtils
    {
        private static ChannelFactory<IUserService> userService = new ChannelFactory<IUserService>(Constants.EndPointUserService);
        private static ChannelFactory<IAnswerSheetService> answerSheetService = new ChannelFactory<IAnswerSheetService>(Constants.EndPointAnswerSheetService);
        private static ChannelFactory<IExamService> examService = new ChannelFactory<IExamService>(Constants.EndPointExamService);
        private static ChannelFactory<IQuestionService> questionService = new ChannelFactory<IQuestionService>(Constants.EndPointQuestionService);

        public static  ChannelFactory getEndPoint(string endPointName)
        {
            switch (endPointName)
            {
                case Constants.EndPointAnswerSheetService:
                    return answerSheetService;
                case Constants.EndPointQuestionService:
                    return questionService;
                case Constants.EndPointUserService:
                    return userService;
                default :
                    return examService;
            }
        }
    }
}
