using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitAppService _unitAppService;

        public UnitController(IUnitAppService unitAppService)
        {
            _unitAppService = unitAppService;
        }

        public ActionResult Index()
        {
            return View(_unitAppService.GetAll());
        }

        public ActionResult Create()
        {
            return View(new UnitViewModel());
        }

        [HttpPost]
        public ActionResult Create(UnitViewModel unitViewModel)
        {     
            if (ModelState.IsValid)
            {
                _unitAppService.Insert(null); //unitViewModel
                return RedirectToAction("Index");
            }
            return View(unitViewModel);
        }

        public ActionResult Edit(int id)
        {
            if (id>0)
            {
                return View(_unitAppService.GetById(id));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(UnitViewModel unitViewModel)
        {
            if(_unitAppService.VerifyUnitExists(unitViewModel))
                ModelState.AddModelError(string.Empty, "O campo Simbolo não deve ser duplicado! Tente outra opção ");

            if (ModelState.IsValid)
            {
                _unitAppService.Update(unitViewModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id, string description, string symbol)
        {
            UnitViewModel unitViewModel = new UnitViewModel()
            {
                Id = id,
                Description = description,
                Symbol = symbol
            };
            return View(unitViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    _unitAppService.Delete(id);

                }
            }
            return RedirectToAction("Index");
        }

        public void get()
        {
            //Expression<Func<UnitViewModel, bool>> filter = (UnitViewModel p) => p.Description == "Metros";
            //Func<IQueryable<UnitViewModel>, IOrderedQueryable<UnitViewModel>> orderBy  = e=>e.OrderBy(p => p.Description);
            //var x = _unitAppService.Get(filter, orderBy, "");
        }

    }
}
