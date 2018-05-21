using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class M_UserController : Controller
    {
        // GET: M_User
        public ActionResult Index()
        {
            return View();
        }

        //LIST
        public ActionResult List()
        {
            return PartialView("_List");
        }
        
        //CREATE
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        //EDIT
        public ActionResult Edit()
        {
            return PartialView("_Edit");
        }

        //DELETE
        public ActionResult Delete()
        {
            return PartialView("_Delete");
        }
    }
}