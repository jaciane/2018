using Application.Interfaces;
using Application.ViewModels;
using Domain;
using Domain.Enum;
using Domain.Util;
using Identity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private IParameterAppService _parameterAppService;
        private MailModel mailModel;

        public HomeController(IParameterAppService parameterAppService)
        {
            _parameterAppService = parameterAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel contact)
        {
            Identity.Configuration.MailService mailService = new Identity.Configuration.MailService(_parameterAppService);
            mailService.SetMailParameters();
            contact.To = EnumDescription.GetEnumDescription(MailParametersEnum.EMAIL);
            contact.Subject = "Contate-nos";
            MailMessages mailMessage = new MailMessages(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Templates/MailTemplate.txt"));
            contact.Body= mailMessage.ContactMessage(EnumDescription.GetEnumDescription(MailParametersEnum.USERNAME), contact.Body, contact.EmitterName, contact.From);
            mailService.SendAsync(contact);
            TempData["mailMessage"] = "E-mail enviado com sucesso!!";
            return View("Contact");
        }

        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Client()
        {
            return View();
        }
        public ActionResult More()
        {
            return View();
        }
    }

}