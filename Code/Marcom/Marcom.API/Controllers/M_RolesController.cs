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
    public class M_RolesController : ApiController
    {
        // GET: api/M_Roles
        public IEnumerable<M_RoleViewModel> Get()
        {
            return M_RoleRepo.Get();
        }

        // GET: api/M_Roles/5
        public M_RoleViewModel Get(int id)
        {
            return M_RoleRepo.GetById(id);
        }

        // POST: api/M_Roles
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/M_Roles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/M_Roles/5
        public void Delete(int id)
        {
        }
    }
}
