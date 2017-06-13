using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Common
{
    public static class Email
    {
        public static string SendMail(string From, string To, string Subject, string Mail)
        {
            string Status = "";

            try
            {
                if (From != "" && To != "" && Subject != "" && Mail != "")
                {
                    using (SmtpClient SMTPClient = new SmtpClient())
                    {
                        SMTPClient.Host = AppSettings.ReadKey("SMTPAddress");
                        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                        MailMessage SendMailMessage = new MailMessage(new MailAddress(From), new MailAddress(To));
                        SendMailMessage.IsBodyHtml = true;
                        SendMailMessage.Subject = Subject;
                        SendMailMessage.Body = Mail;
                        SMTPClient.Credentials = NetworkCred;
                        SMTPClient.Send(SendMailMessage);
                    }

                    Status = "1";
                }
                else
                {
                    Status = "0";
                }
            }
            catch (Exception expc)
            {
                ErrorLog.WriteLog(expc);
                Status = "-1";
            }
            return Status;
        }
    }
}
