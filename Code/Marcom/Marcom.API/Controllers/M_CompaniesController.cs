using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Marcom.ViewModel;
using Marcom.Repository;

namespace Marcom.API.Controllers
{
    public class M_CompaniesController : ApiController
    {
        // GET: api/M_Companies
        public IEnumerable<M_CompanyViewModel> Get()
        {
            return M_CompanyRepo.Get();
        }

        // GET: api/M_Companies/5
        public M_CompanyViewModel Get(int id)
        {
            return M_CompanyRepo.GetById(id);
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
