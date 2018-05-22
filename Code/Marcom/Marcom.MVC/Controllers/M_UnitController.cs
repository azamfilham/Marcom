using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class M_UnitController : Controller
    {
        // GET: M_Unit
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult List()
        {
            return View("_List", M_UnitRepo.Get());
        }



        //Get Create
        //[CustomAuthorize(Roles = "Devision", AccessLevel = "W")]
        public ActionResult Create()
        {
            ViewBag.M_UnitList = new SelectList(M_UnitRepo.Get(), "Id", "Description");
            return View("_Create");
        }

        //POST Create
        [HttpPost]
        public ActionResult Create(M_UnitViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (M_UnitRepo.update(model));
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json(new { success = false, massage = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, massage = "Invalid" }, JsonRequestBehavior.AllowGet);

        }


        //Get Edit
        //[CustomAuthorize(Roles = "Devision", AccessLevel = "W")]
        public ActionResult Edit(int Id)
        {
            return View("_Edit", M_UnitRepo.GetById(Id));
        }

        //Post Edit
        [HttpPost]
        public ActionResult Edit(M_UnitViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (M_UnitRepo.update(model));
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json(new { success = false, massage = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, massage = "Invalid" }, JsonRequestBehavior.AllowGet);

        }

        //Get Delete
        public ActionResult Delete(int id)
        {
            return View("_Delete", M_UnitRepo.GetById(id));
        }

        //Post Delete
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = (M_UnitRepo.Delete(id));
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }



            return Json(new { success = false, massage = "Error" }, JsonRequestBehavior.AllowGet);
        }
        //Get Detail
        public ActionResult Details(int id)
        {
            return View(M_UnitRepo.GetById(id));
        }
    }
}