using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marcom.API.Controllers
{
    public class M_CompaniesController : ApiController
    {
        // GET: api/M_Companies
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/M_Companies/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/M_Companies
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/M_Companies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/M_Companies/5
        public void Delete(int id)
        {
        }
    }
}
