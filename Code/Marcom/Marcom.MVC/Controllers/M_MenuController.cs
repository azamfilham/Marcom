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

     

        //GET EDIT
        public ActionResult Edit(int id)
        {
            return View("_Edit", M_MenuRepo.GetById(id));
        }

  
    }
}