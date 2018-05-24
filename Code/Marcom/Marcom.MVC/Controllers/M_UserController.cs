using Marcom.Repository;
using Marcom.ViewModel;
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

        //CREATE
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        
        //EDIT
        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", M_UserRepo.GetById(id));
        }

        //DETAILS
        public ActionResult View(int id)
        {
            return PartialView("_View", M_UserRepo.GetById(id));
        }        
        
        //DELETE
        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", M_UserRepo.GetById(id));
        }
    }
}