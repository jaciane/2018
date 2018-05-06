using Application.Interfaces;
using Application.ViewModels;
using Domain.Enum;
using Domain.Util;
using Microsoft.AspNet.Identity;
using MvcFlashMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly IProfileAppService _profileAppService;
        private string activeStatus = ((int)GenericStatusEnum.Active).ToString();

        public UserController(IUserAppService userAppService, IProfileAppService profileAppService)
        {
            _userAppService = userAppService;
            _profileAppService = profileAppService;
        }

        //[ClaimsAuthorize(claimType: TypePermissionEnum.USER, claimValue: ValuePermissionEnum.CONSULT)]
        public ActionResult Index(string ResearchName, string ResearchEmail, string ResearchCpf, string ResearchCompany, string ResearchProfile, string ResearchActive)
        {
            var name = (ResearchName == null || ResearchName.Trim().Equals("")) ? null : ResearchName.Trim();
            var email = (ResearchEmail == null || ResearchEmail.Trim().Equals("")) ? null : ResearchEmail.Trim();
            var cpf = (ResearchCpf == null || ResearchCpf.Trim().Equals("")) ? null : Formatter.RemoveFormattingOfCnpjOrCpf(ResearchCpf);
            var company = (ResearchCompany == null || ResearchCompany.Trim().Equals("")) ? null : ResearchCompany.Trim();
            var profile = (ResearchProfile == null || ResearchProfile.Trim().Equals("")) ? null : ResearchProfile.Trim();
            var active = (ResearchActive == null || ResearchActive.Trim().Equals("")) ? null : ResearchActive.Trim();
            UserViewIndex Users = new UserViewIndex();

            if (name == null && email == null && cpf == null && company == null && profile == null && active == null)
            {
                Users.UserList = new List<UserViewModel>(_userAppService.GetAll()?.Where(e => e.Active.Equals("1")));
            }
            else
            {

                Expression<Func<UserViewModel, bool>> filter = null;

                filter = (UserViewModel p) => ((name != null) ? p.Name.ToUpper().Contains(name.ToUpper()) : true)
                && ((email != null) ? p.Email.ToUpper().Contains(email.ToUpper()) : true)
                && ((cpf != null) ? p.Cpf.ToUpper().Contains(cpf.ToUpper()) : true)
                && ((profile != null) ? p.Profile.Name.ToUpper().Contains(profile.ToUpper()) : true)
                && ((active != null) ? p.Active.Equals(active) : true);

                Users.UserList = new List<UserViewModel>(_userAppService.Get(filter, orderBy: q => q.OrderBy(d => d.Name)));
                Users.ResearchActive = ResearchActive;
                Users.ResearchName = ResearchName;
                Users.ResearchEmail = ResearchEmail;
                Users.ResearchCpf = ResearchCpf;
                Users.ResearchProfile = ResearchProfile;
            }
            return View(Users);
        }

        //[ClaimsAuthorize(claimType: TypePermissionEnum.USER, claimValue: ValuePermissionEnum.CHANGE)]
        public ActionResult Edit(int id)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            UserViewModel user = _userAppService.GetById(id);
            if (user == null)
            {
                return new RedirectToRouteResult(new RouteValueDictionary(new { action = "ModalNotFound", controller = "Error" }));
            }
            FulFillList(user);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            FulFillList(user);
            if (!ModelState.IsValid) return View(user);
            user.Cpf = Formatter.RemoveFormattingOfCnpjOrCpf(user.Cpf);

            List<string> errors = _userAppService.UpdateProfile(user);
            if (errors?.Count > 0)
            {
                if (errors.Contains(CodLogErrorEnum.CODELOGERROR.ToString()))
                    this.Flash("Error", ResultMessages.AplicationException());
                else
                {
                    foreach (string error in errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                    return View(user);
                }
            }
            else
                this.Flash("Success", ResultMessages.Success());

            return RedirectToAction("Index");
        }

        //[ClaimsAuthorize(claimType: TypePermissionEnum.USER, claimValue: ValuePermissionEnum.DELETE)]
        public ActionResult Delete(int id, string name, string email)
        {
            UserViewModel user = new UserViewModel()
            {
                Id = id,
                Name = name,
                Email = email
            };
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            List<string> errors = _userAppService.Delete(id);
            if (errors?.Count > 0)
            {
                if (errors.Contains(CodLogErrorEnum.CODELOGERROR.ToString()))
                    this.Flash("Error", ResultMessages.AplicationException());
                else
                {
                    var errorListGroupped = errors.Aggregate((i, j) => i + "<br/>" + j);
                    this.Flash("Error", errorListGroupped);
                }
            }
            else
                this.Flash("Success", ResultMessages.Success());

            return RedirectToAction("Index");
        }

        public ActionResult Details()
        {
            var idUser = User.Identity.GetUserId();
            var user = _userAppService.GetById(Int32.Parse(idUser));
            return View(user);
        }

        private void FulFillList(UserViewModel user)
        {
            Expression<Func<ProfileViewModel, bool>> filterProfile = (ProfileViewModel p) => (p.Active.Equals(activeStatus));
            var Profiles = _profileAppService.Get(filterProfile, orderBy: q => q.OrderBy(d => d.Name));
            user.ProfileList = new List<ProfileViewModel>(Profiles);
        }
    }
}