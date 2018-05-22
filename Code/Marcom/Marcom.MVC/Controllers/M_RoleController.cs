using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class M_RoleController : Controller
    {
        // GET: M_Role
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
    }
}