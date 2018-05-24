using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marcom.API.Controllers
{
    public class T_PromotionsController : ApiController
    {
        // GET: api/T_Promotions
        public IEnumerable<T_PromotionViewModel> Get()
        {
            return T_PromotionRepo.Get();
        }

        // GET: api/T_Promotions/5
        public T_PromotionViewModel Get(int id)
        {
            return T_PromotionRepo.GetById(id);
        }

        // POST: api/T_Promotions
        public void Post([FromBody]T_PromotionViewModel value)
        {
        }

        // PUT: api/T_Promotions/5
        public void Put(int id, [FromBody]T_PromotionViewModel value)
        {
        }

        // DELETE: api/T_Promotions/5
        public void Delete(int id)
        {
        }
    }
}
