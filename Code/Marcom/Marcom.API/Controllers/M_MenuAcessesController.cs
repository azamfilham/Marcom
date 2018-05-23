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
    public class M_MenuAcessesController : ApiController
    {
        // GET: api/M_MenuAcesses
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/M_MenuAcesses/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/M_MenuAcesses
        public Responses Post([FromBody]M_MenuAccessViewModel entity)
        {
            return M_MenuAccessRepo.Update(entity);
        }

        // PUT: api/M_MenuAcesses/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/M_MenuAcesses/5
        public void Delete(int id)
        {
        }
    }
}
