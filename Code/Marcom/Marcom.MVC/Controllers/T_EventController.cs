using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class T_EventController : Controller
    {
        // GET: Tr_Event
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            T_EventViewModel model = new T_EventViewModel();
            model.Code = T_EventRepo.GetNewCode();
            return PartialView("_Create", model);
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", T_EventRepo.GetById(id));
        }

        public ActionResult View(int id)
        {
            return PartialView("_View", T_EventRepo.GetById(id));
        }
    }
}