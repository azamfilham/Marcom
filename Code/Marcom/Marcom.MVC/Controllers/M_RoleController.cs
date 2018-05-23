using Marcom.Repository;
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
        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", M_RoleRepo.GetById(id));
        }
        public ActionResult View(int id)
        {
            return PartialView("_View", M_RoleRepo.GetById(id));
        }
        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", M_RoleRepo.GetById(id));
        }
    }
}