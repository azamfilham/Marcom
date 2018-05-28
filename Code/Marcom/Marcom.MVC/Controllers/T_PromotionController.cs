using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcom.MVC.Controllers
{
    public class T_PromotionController : Controller
    {
        // GET: T_Promotion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return PartialView("_Add");
        }
        
        public ActionResult Create(int idEvent, int idDesign)
        {            
            return View("_Create", T_PromotionRepo.GetByEventandDesign(idEvent, idDesign));
        }

        public ActionResult Listby(int DesignId)
        {
            return PartialView("_List", T_DesignItemRepo.GetByDesignId(DesignId));
        }
    }
}