using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
//using Application.Interfaces;
//using Domain;
using System.Collections.Generic;

namespace Identity.Configuration
{
    //public class MailService : IIdentityMessageService
    //{
    //    private string _mail { get; set; }
    //    private string _password { get; set; }
    //    private string _SMTP { get; set; }
    //    private string _port { get; set; }
    //    private string _displayName { get; set; }
    //    private readonly IParameterAppService _parameterAppService;

    //    public MailService(IParameterAppService parameterAppService)
    //    {
    //        _parameterAppService = parameterAppService;
    //    }

    //    public Task SendAsync(IdentityMessage message)
    //    {
    //        var mail = _mail;
    //        var password = _password;
    //        var smtp = _SMTP;
    //        var port = _port;
    //        var displayName = _displayName;
    //        var path = System.Web.HttpContext.Current.Server.MapPath("~//Content/img/br_logo_no_margin.png");
    //        MailModel mailModel = new MailModel(mail, password, smtp, port, displayName, path);
    //        mailModel.Body = message.Body;
    //        mailModel.Subject = message.Subject;
    //        mailModel.To = new List<MailAddress>() { new MailAddress(message.Destination) };
    //        Domain.Util.MailService.SendEmail(mailModel);
    //        return Task.FromResult(0);
    //    }

    //    public void SetMailParameters()
    //    {
    //        var result = _parameterAppService.GetParameterByType("MAIL");
    //        _mail = result["MAIL"];
    //        _password = result["PASSWORD"];
    //        _SMTP = result["SMTP"];
    //        _port = result["PORT"];
    //        _displayName = result["DISPLAYNAME"];
    //    }
    //}
}