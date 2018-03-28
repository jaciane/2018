using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Domain.Util
{
    public class MailService
    {
        public static Task SendEmail(MailModel mailModel) {
            MailMessage mail = new MailMessage { From = mailModel._From };
            foreach (var item in mailModel.To)
            {
                mail.Bcc.Add(item);
            }
            mail.Subject = mailModel.Subject;
            mail.IsBodyHtml = true;
            
            var inline = new LinkedResource(mailModel._PathImage);
            inline.ContentId = Guid.NewGuid().ToString();

            mailModel.Body = mailModel.Body.Replace("{IMAGE}", inline.ContentId);
            var alternativeView = AlternateView.CreateAlternateViewFromString(mailModel.Body, null, "text/html");
            alternativeView.LinkedResources.Add(inline);
            mail.AlternateViews.Add(alternativeView);

            mailModel._SmtpClient.Send(mail);
            return Task.FromResult(0);
        }
        
    }
}
