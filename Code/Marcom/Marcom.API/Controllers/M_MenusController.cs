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
    public class M_MenusController : ApiController
    {
        // GET: api/M_Menus
        public IEnumerable<M_MenuViewModel> Get()
        {
            return M_MenuRepo.Get();
        }

        // GET: api/M_Menus/5
        public M_MenuViewModel Get(int id)
        {
            return M_MenuRepo.GetById(id); 
        }

        // POST: api/M_Menus
        public Responses Post([FromBody]M_MenuViewModel entity)
        {
            return M_MenuRepo.Update(entity);
        }

        // PUT: api/M_Menus/5
        public Responses Put(int id, [FromBody]M_MenuViewModel entity)
        {
            return M_MenuRepo.Update(entity);
        }

        // DELETE: api/M_Menus/5
        public Responses Delete(int id)
        {
            return M_MenuRepo.Delete(id);
        }
    }
}
