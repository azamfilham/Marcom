﻿using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class T_SouvenirItemController : Controller
    {
         // GET: M_Unit
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult List()
        {
            return View("_List", T_SouvinerItemRepo.Get());
        }



        //Get Create
        //[CustomAuthorize(Roles = "Devision", AccessLevel = "W")]
        public ActionResult Create()
        {
            //ViewBag.M_UnitList = new SelectList(T_SouvinerItemRepo.Get(), "Id", "Description");
            
            T_SouvinerItemViewModel modelCode = new T_SouvinerItemViewModel();  
            modelCode.TransactionCode = T_SouvinerItemRepo.GetNewCode();

            return PartialView("_Create", modelCode);
        }

        //POST Create
        //[HttpPost]
        //public ActionResult Create(T_SouvinerItemViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Responses responses = (T_SouvinerItemRepo.update(model));
        //        if (responses.Success)
        //        {
        //            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //        }

        //        else
        //        {
        //            return Json(new { success = false, massage = "Error msg" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    return Json(new { success = false, massage = "Invalid" }, JsonRequestBehavior.AllowGet);

        //}


        //Get Edit
        //[CustomAuthorize(Roles = "Devision", AccessLevel = "W")]
        public ActionResult Edit(int Id)
        {
            return View("_Edit", T_SouvinerItemRepo.GetById(Id));
        }

        //Post Edit
        //[HttpPost]
        //public ActionResult Edit(T_SouvinerItemViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Responses responses = (T_SouvinerItemRepo.update(model));
        //        if (responses.Success)
        //        {
        //            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //        }

        //        else
        //        {
        //            return Json(new { success = false, massage = "Error msg" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    return Json(new { success = false, massage = "Invalid" }, JsonRequestBehavior.AllowGet);

        //}

        //Get Delete
        public ActionResult Delete(int id)
        {
            return View("_Delete", T_SouvinerItemRepo.GetById(id));
        }

        //Post Delete
        //[HttpPost]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    Responses responses = (T_SouvinerItemRepo.Delete(id));
        //    if (responses.Success)
        //    {
        //        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //    }



        //    return Json(new { success = false, massage = "Error" }, JsonRequestBehavior.AllowGet);
        //}

        //Get Detail
        public ActionResult View(int id)
        {
            return View("_View",T_SouvinerItemRepo.GetById(id));
        }
    }
}