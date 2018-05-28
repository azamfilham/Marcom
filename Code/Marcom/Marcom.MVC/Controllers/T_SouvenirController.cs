using Marcom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class T_SouvenirController : Controller
    {
        // GET: T_Souvenir
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit",T_SouvenirRepo.GetById(id));
        }

        public ActionResult View(int id)
        {
            return PartialView("_View", T_SouvenirRepo.GetById(id));
        }

        public ActionResult AddItem()
        {
            return PartialView("_AddItem");
        }

    }
}