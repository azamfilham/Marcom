﻿using Marcom.Repository;
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

        ////POST CREATE
        //[HttpPost]
        //public ActionResult Create(M_MenuViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Responses responses = (M_MenuRepo.Update(model));
        //        if (responses.Success)
        //        {
        //            return Json(new { succes = true }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new { succes = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    return Json(new { succes = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        //}

        //GET EDIT
        public ActionResult Edit(int id)
        {
            return View("_Edit", M_MenuRepo.GetById(id));
        }

        //POST EDIT
        [HttpPost]
        public ActionResult Edit(M_MenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (M_MenuRepo.Update(model));
                if (responses.Success)
                {
                    return Json(new { succes = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { succes = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { succes = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }
    }
}