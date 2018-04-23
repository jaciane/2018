using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Domain
{
    public class MailModel
    {
        public MailModel(string UserMail, string UserPassword, string UserSmtp, string Port, string DisplayName, string PathImage)
        {
            _UserMail = UserMail;
            _UserPassword = UserPassword;
            _UserSmtp = UserSmtp;
            _Port = Port;
            _PathImage = PathImage;
            //_From = new MailAddress(From, DisplayName);
            _SmtpClient = new SmtpClient(_UserSmtp, Convert.ToInt32(_Port));
            _SmtpClient.UseDefaultCredentials = false;
            _Credentials = new NetworkCredential(_UserMail, _UserPassword);
            _SmtpClient.Credentials = _Credentials;
            _SmtpClient.EnableSsl = true;
        }
        private string _Port { get; set; }
        private string _UserMail { get; set; }
        private string _UserPassword { get; set; }
        private string _UserSmtp { get; set; }

        public MailAddress _From { get; private set; }
        public SmtpClient _SmtpClient { get; private set; }
        public NetworkCredential _Credentials { get; private set; }
        public string _PathImage { get; private set; }

        public List<MailAddress> To { get; set; }
        public MailAddress From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
