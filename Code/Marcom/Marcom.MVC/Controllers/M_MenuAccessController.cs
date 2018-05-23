using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class M_MenuAccessController : Controller
    {
        // GET: M_MenuAccess
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        public ActionResult Edit()
        {
            return PartialView("_Edit");
        }
    }
}