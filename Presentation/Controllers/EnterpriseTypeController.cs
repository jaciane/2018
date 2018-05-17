using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class EnterpriseTypeController : Controller
    {
        // GET: EnterpriseType
        public ActionResult Index()
        {
            return View();
        }

        // GET: EnterpriseType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnterpriseType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnterpriseType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EnterpriseType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnterpriseType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EnterpriseType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnterpriseType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
