using System;
using System.ServiceModel;
using OnlineExamSystem.BAL;
using log4net;

namespace OESServiceHost
{
    class Program
    {
        /// <summary>
        /// Represents the server host main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ILog loger = LogManager.GetLogger(typeof(Program));
            using (ServiceHost userhost = new ServiceHost(typeof(UserService)))
            using (ServiceHost examHost = new ServiceHost(typeof(ExamService)))
            using (ServiceHost questionHost = new ServiceHost(typeof(QuestionService)))
            using (ServiceHost answerSheetHost = new ServiceHost(typeof(AnswerSheetService)))
            {
                answerSheetHost.Opened += delegate
                {
                    Console.WriteLine(typeof(AnswerSheetService).Name + Contants.ServiceOpenSuccessMessage + DateTime.Now);
                };
                questionHost.Opened += delegate
                {
                    Console.WriteLine(typeof(QuestionService).Name + Contants.ServiceOpenSuccessMessage + DateTime.Now);
                };
                examHost.Opened += delegate
                {
                    Console.WriteLine(typeof(ExamService).Name + Contants.ServiceOpenSuccessMessage + DateTime.Now);
                };
                userhost.Opened += delegate
                {
                    Console.WriteLine(typeof(UserService).Name + Contants.ServiceOpenSuccessMessage + DateTime.Now);
                };

                try
                {
                    userhost.Open();
                }
                catch (Exception ex)
                {
                    loger.Warn(ex);
                
                }
                try
                {
                    examHost.Open();
                }
                catch (Exception ex)
                {
                    loger.Warn(ex);

                }
                try
                {
                    questionHost.Open();
                }
                catch (Exception ex)
                {
                    loger.Warn(ex);
                }
                
                try
                {
                    answerSheetHost.Open();
                }
                catch (Exception ex)
                {
                    loger.Warn(ex);

                }

                Console.Read();
            }
        }
    }
}