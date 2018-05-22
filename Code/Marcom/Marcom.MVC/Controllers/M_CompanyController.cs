using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class M_CompanyController : Controller
    {
        // GET: M_Company
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {            
            return PartialView("_Create");
        }
        //POST CREATE
        [HttpPost]
        public ActionResult Create(M_CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (M_CompanyRepo.Update(model));
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }
    }
}