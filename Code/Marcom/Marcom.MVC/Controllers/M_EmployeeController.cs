using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class M_EmployeeController : Controller
    {
        // GET: M_Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        ////POST CREATE
        //[HttpPost]
        //public ActionResult Create(M_EmployeeViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Responses responses = (M_EmployeeRepo.Update(model));
        //        if (responses.Success)
        //        {
        //            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", M_EmployeeRepo.GetById(id));
        }

        public ActionResult View(int id)
        {
            return PartialView("_View", M_EmployeeRepo.GetById(id));
        }

        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", M_EmployeeRepo.GetById(id));
        }
    }
}