using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marcom.API.Controllers
{
    public class M_UsersController : ApiController
    {
        // GET: api/M_Users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/M_Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/M_Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/M_Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/M_Users/5
        public void Delete(int id)
        {
        }
    }
}
