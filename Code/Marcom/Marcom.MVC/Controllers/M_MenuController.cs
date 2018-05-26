using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class M_MenuController : Controller
    {
        // GET: M_Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        //GET CREATE
        public ActionResult Create()
        {
            return View("_Create");
        }

     

        //GET EDIT
        public ActionResult Edit(int id)
        {
            return View("_Edit", M_MenuRepo.GetById(id));
        }


        
        [HttpPost]
        public JsonResult checkNameValidate(M_MenuViewModel name)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (M_MenuRepo.Update(name));
                if (responses.Success)
                {
                    return Json(new { succes = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Email Already Exists!", JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { succes = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);

        }

        

    }
}