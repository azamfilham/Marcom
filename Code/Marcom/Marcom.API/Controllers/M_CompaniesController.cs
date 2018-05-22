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
        public Responses Post([FromBody]M_CompanyViewModel entity)
        {
            return M_CompanyRepo.Update(entity);
        }

        // PUT: api/M_Companies/5
        public Responses Put(int id, [FromBody]M_CompanyViewModel entity)
        {
            entity.Id = id;
            return M_CompanyRepo.Update(entity);
        }

        // DELETE: api/M_Companies/5
        public Responses Delete(int id)
        {
            return M_CompanyRepo.Delete(id);
        }
    }
}
