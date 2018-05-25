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
        [HttpGet]
        public ActionResult Create(int idEvent, int idDesign)
        {
            T_PromotionViewModel model = new T_PromotionViewModel();
            model.TEventId = idEvent;
            model.TDesignId = idDesign;
            T_MarketingPromotionViewModel models = new T_MarketingPromotionViewModel();
            models.Promotion = model;
            //models.Promotion.TDesignId = model.TDesignId;
            return View("_Create",models);
        }
    }
}