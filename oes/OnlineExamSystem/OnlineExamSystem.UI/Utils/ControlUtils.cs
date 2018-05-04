using System.Windows.Forms;
using System;
using log4net;

namespace OnlineExamSystem.UI
{
    /// <summary>
    /// Provides function related to page display
    /// </summary>
    public class ControlUtils
    {
        /// <summary>
        /// Formats the number with a style.
        ///     Example:
        ///         FormatToString(3);  The return is "03".
        ///         FormatToString(12);  The return is "12".
        /// </summary>
        /// <param name="number">number</param>
        /// <returns></returns>
        public static string FormatToString(int number)
        {
            if (number < Constants.Boundary && number >= 0)
            {
                return Constants.PlaceholderTimeDisplay + number;
            }
            else
            {
                return number.ToString();
            }
        }

        /// <summary>
        /// Formats the time to string.
        /// </summary>
        /// <param name="timeSpan">The timeSpan.</param>
        /// <returns>The returns of format similar to "08:12:30"</returns>
        public static string SetTimeDisplay(TimeSpan timeSpan)
        {
            return ControlUtils.FormatToString(timeSpan.Hours) + Constants.BlankCharacterTimeDisplay
                + ControlUtils.FormatToString(timeSpan.Minutes) + Constants.BlankCharacterTimeDisplay 
                + ControlUtils.FormatToString(timeSpan.Seconds);
        }

        /// <summary>
        /// Refresh
        /// </summary>
        public static void reloadList()
        {
            StudentMainForm main = Session.formDictionary[Constants.FormKeyMain] as StudentMainForm;

            try 
            {
                if (main != null)
                {
                    main.pnlListBody.Controls.Clear();
                    main.pnlNoticBack.Controls.Clear();
                    main.InitNotice();
                    main.LoadList();
                    main.ResetPageBlock();
                }
                else
                {
                    // Nothing to do.
                }
            }
            catch (Exception ex) 
            {
                ILog logger = LogManager.GetLogger(typeof(ControlUtils));
                logger.Warn(ex);
            }

        }
    }
}