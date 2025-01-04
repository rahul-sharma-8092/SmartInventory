using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class EmailService
    {
        public static bool SendEmail(EmailMsg obj)
        {
            if (obj != null && !string.IsNullOrEmpty(obj.To))
            {
                try
                {
                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress("rahulsh9523@gmail.com", "Smart Inventory | Rahul Sharma"),
                        Subject = obj.Subject,
                        Body = obj.Body,
                        IsBodyHtml = obj.IsHtml
                    };

                    string[] recipients = obj.To.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string recipient in recipients)
                    {
                        mail.To.Add(recipient.Trim());
                    }

                    if (!string.IsNullOrEmpty(obj.CC))
                    {
                        string[] ccRecipients = obj.CC.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string ccRecipient in ccRecipients)
                        {
                            mail.CC.Add(ccRecipient.Trim());
                        }
                    }

                    if (!string.IsNullOrEmpty(obj.BCC))
                    {
                        string[] bccRecipients = obj.BCC.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string bccRecipient in bccRecipients)
                        {
                            mail.Bcc.Add(bccRecipient.Trim());
                        }
                    }

                    if (obj.Attachment != null && obj.Attachment.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(obj.Attachment.FileName);
                        mail.Attachments.Add(new Attachment(obj.Attachment.InputStream, fileName));
                    }

                    SmtpClient smtp = new SmtpClient();
                    smtp.Send(mail);

                    obj.IsSent = true;
                    return obj.IsSent;
                }
                catch (Exception ex)
                {
                    string msg = $"Error sending email to '{obj.To}':: ---ex.Message--- {ex.Message} | ---ex.InnerException--- {ex.InnerException.ToString()}";
                    FileLogger.WriteLog("EmailService", msg, LogLevel.Error);
                    return obj.IsSent;
                }
            }
            return false;
        }
    }
}
