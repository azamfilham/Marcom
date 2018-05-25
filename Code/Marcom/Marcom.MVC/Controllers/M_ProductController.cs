using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class M_ProductController : Controller
    {
        // GET: M_Product
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult List()
        {
            return View("_List", M_ProductRepo.Get());
        }



        //Get Create
        //[CustomAuthorize(Roles = "Devision", AccessLevel = "W")]
        public ActionResult Create()
        {
            //ViewBag.M_UnitList = new SelectList(M_ProductRepo.Get(), "Id", "Description");
            return View("_Create");
        }

        //POST Create
        [HttpPost]
        public ActionResult Create(M_ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (M_ProductRepo.update(model));
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
            return View("_Edit", M_ProductRepo.GetById(Id));
        }

        //Post Edit
        [HttpPost]
        public ActionResult Edit(M_ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (M_ProductRepo.update(model));
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
            return View("_Delete", M_ProductRepo.GetById(id));
        }

        //Post Delete
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = (M_ProductRepo.Delete(id));
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }



            return Json(new { success = false, massage = "Error" }, JsonRequestBehavior.AllowGet);
        }

        //Get Detail
        public ActionResult Views(int id)
        {
            return View("_View", M_ProductRepo.GetById(id));
        }
    }
}