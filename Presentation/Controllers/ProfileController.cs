using Application.Interfaces;
using System.Web.Mvc;
using MvcFlashMessages;
using Application.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Domain.Util;
using System.Web.Routing;
using System.Web;
using System.Linq.Expressions;
using System;
using Domain.Enum;

namespace Presentation.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileAppService _profileAppService;
        private readonly IPermissionAppService _permissionAppService;

        public ProfileController(IProfileAppService profileAppService, IPermissionAppService permissionAppService)
        {
            _profileAppService = profileAppService;
            _permissionAppService = permissionAppService;
        }

       // [ClaimsAuthorize(claimType: TypePermissionEnum.PROFILE, claimValue: ValuePermissionEnum.CONSULT)]
        public ActionResult Index(string ResearchName, string ResearchActive)
        {
            var name = (ResearchName == null || ResearchName.Trim().Equals("")) ? null : ResearchName.Trim();
            var active = (ResearchActive == null || ResearchActive.Trim().Equals("")) ? null : ResearchActive.Trim();
            ProfileViewIndex Profiles = new ProfileViewIndex();

            if (name == null && active == null)
            {
                Profiles.ProfileList = new List<ProfileViewModel>(_profileAppService.GetAll());
            }
            else
            {
                Expression<Func<ProfileViewModel, bool>> filter = null;

                filter = (ProfileViewModel p) => ((name != null) ? p.Name.ToUpper().Contains(name.ToUpper()) : true)
                && ((active != null) ? p.Active.Equals(active) : true);

                Profiles.ProfileList = new List<ProfileViewModel>(_profileAppService.Get(filter, orderBy: q => q.OrderBy(d => d.Name)));
                Profiles.ResearchName = ResearchName;
            }
            return View(Profiles);
        }

       // [ClaimsAuthorize(claimType: TypePermissionEnum.PROFILE, claimValue: ValuePermissionEnum.INSERT)]
        public ActionResult Create()
        {
            var profileViewCreate = new ProfileViewModel();
            GroupPermissions(profileViewCreate);
            return View(profileViewCreate);
        }

        [HttpPost]
        public ActionResult Create(ProfileViewModel profileViewCreate)
        {
            GroupPermissions(profileViewCreate);
            if (!ModelState.IsValid) return View(profileViewCreate);

            List<string> errors = _profileAppService.Insert(profileViewCreate);
            if (errors?.Count > 0)
            {
                if (errors.Contains(CodLogErrorEnum.CODELOGERROR.ToString()))
                    this.Flash("Error", ResultMessages.AplicationException());
                else
                {
                    AddModelStateError(errors);
                    return View(profileViewCreate);
                }
            }
            else
                this.Flash("Success", ResultMessages.Success());

            return RedirectToAction("Index");
        }

        //[ClaimsAuthorize(claimType: TypePermissionEnum.PROFILE, claimValue: ValuePermissionEnum.CHANGE)]
        public ActionResult Edit(int id)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            ProfileViewModel profileViewEdit = _profileAppService.GetById(id);
            if (profileViewEdit == null)
            {
                return new RedirectToRouteResult(new RouteValueDictionary(new { action = "ModalNotFound", controller = "Error" }));
            }
            GroupPermissions(profileViewEdit);
            GetIdPermissions(profileViewEdit);
            return View(profileViewEdit);
        }

        [HttpPost]
        public ActionResult Edit(ProfileViewModel profileViewEdit)
        {
            GroupPermissions(profileViewEdit);
            if (!ModelState.IsValid) return View(profileViewEdit);

            List<string> errors = _profileAppService.Update(profileViewEdit);
            if (errors?.Count > 0)
            {
                if (errors.Contains(CodLogErrorEnum.CODELOGERROR.ToString()))
                    this.Flash("Error", ResultMessages.AplicationException());
                else
                {
                    AddModelStateError(errors);
                    return View(profileViewEdit);
                }
            }
            else
                this.Flash("Success", ResultMessages.Success());

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize(claimType: TypePermissionEnum.PROFILE, claimValue: ValuePermissionEnum.DELETE)]
        public ActionResult Delete(int id, string name, string active)
        {
            ProfileViewModel profileViewDelete = new ProfileViewModel()
            {
                Id = id,
                Name = name,
                Active = active
            };
            return View(profileViewDelete);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            List<string> errors = _profileAppService.Delete(id);
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

        private void GetIdPermissions(ProfileViewModel profile)
        {
            if (profile.AccessList.Count > 0)
            {
                var IdPermissions = profile.AccessList.Select(p => p.IdPermission).ToList();
                profile.SelectedPermissionIdList = IdPermissions;
            }
        }

        private void GroupPermissions(ProfileViewModel profile)
        {
            profile.PermissionList = new List<PermissionViewModel>(_permissionAppService.GetAll());
            profile.PermissionGrouped = profile.PermissionList.GroupBy(u => u.ClaimType).Select(t => t.ToList()).ToList();
        }

        private void AddModelStateError(List<string> errors)
        {
            foreach (string error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }
    }
}
