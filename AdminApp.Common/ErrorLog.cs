using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace AdminApp.Common
{
    public static class ErrorLog
    {
        public static void WriteLog(Exception excp)
        {
            try
            {
                string FileName = "ERROR_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt";
                string ErrorLog = "";

                string ErrorLogFile = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, AppSettings.ReadKey("ErrorLogFolder") + "\\" + FileName);

                if (!File.Exists(ErrorLogFile))
                {
                    File.Create(ErrorLogFile).Close();
                }

                ErrorLog = ErrorLog + "***************************************************";
                ErrorLog = ErrorLog + "\r\nMessage : " + excp.GetBaseException().Message;
                ErrorLog = ErrorLog + "\r\nSource : " + excp.GetBaseException().Source;
                ErrorLog = ErrorLog + "\r\nError : " + excp.StackTrace;
                ErrorLog = ErrorLog + "\r\nStacktrace : " + excp.GetBaseException().StackTrace;
                ErrorLog = ErrorLog + "\r\n" + excp.GetBaseException().TargetSite;
                ErrorLog = ErrorLog + "\r\nDate & Time : " + DateTime.Now.ToString();
                ErrorLog = ErrorLog + "\r\n***************************************************\r\n";

                using (StreamWriter LogWriter = File.AppendText(ErrorLogFile))
                {
                    Log(ErrorLog, LogWriter);
                }
            }
            catch { }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.WriteLine("{0}", logMessage);

        }
    }
}
