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
    public class T_DesignItemsController : ApiController
    {
        // GET: api/T_DesignItems
        public IEnumerable<T_DesignItemViewModel> Get()
        {
            return T_DesignItemRepo.Get();
        }

        // GET: api/T_DesignItems/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public IEnumerable<T_DesignItemViewModel> GetByDesign(int DesignId)
        {
            return T_DesignItemRepo.GetByDesignId(DesignId);
        }

        // POST: api/T_DesignItems
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/T_DesignItems/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/T_DesignItems/5
        public void Delete(int id)
        {
        }
    }
}
