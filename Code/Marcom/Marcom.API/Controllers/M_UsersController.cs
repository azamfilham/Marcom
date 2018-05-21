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
    public class M_UsersController : ApiController
    {
        // GET: api/M_Users
        public IEnumerable<M_UserViewModel> Get()
        {
            return M_UserRepo.Get();
        }

        // GET: api/M_Users/5
        public M_UserViewModel Get(int id)
        {
            return M_UserRepo.GetById(id);
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
