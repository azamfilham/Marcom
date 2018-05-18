using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marcom.API.Controllers
{
    public class T_PromotionItemsController : ApiController
    {
        // GET: api/T_PromotionItems
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/T_PromotionItems/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/T_PromotionItems
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/T_PromotionItems/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/T_PromotionItems/5
        public void Delete(int id)
        {
        }
    }
}
