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
        public Responses Post([FromBody]M_RoleViewModel entity)
        {
            entity.Code = M_RoleRepo.GetNewCode();
            return M_RoleRepo.Update(entity);
        }

        // PUT: api/M_Roles/5
        public Responses Put(int id, [FromBody]M_RoleViewModel entity)
        {
            entity.Id = id;
            return M_RoleRepo.Update(entity);
        }

        // DELETE: api/M_Roles/5
        public Responses Delete(int id)
        {
            return M_RoleRepo.Delete(id);
        }
    }
}
