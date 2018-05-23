using Marcom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class M_SouvenirController : Controller
    {
        // GET: M_Souvenir
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView("_List");
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit",M_SouvenirRepo.GetById(id));
        }
    }
}