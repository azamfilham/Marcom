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
        [HttpGet]
        public IEnumerable<M_MenuViewModel> Get( )
        {
            return M_MenuRepo.Get();
        }

        // GET: api/M_Menus/5
        public M_MenuViewModel Get(int id)
        {
            return M_MenuRepo.GetById(id); 
        }
        [HttpGet]
        [Route("~/api/Menu/M_Menus/{PId}")]
        public IEnumerable<M_MenuViewModel> GetByPId(int PId)
        {
            return M_MenuRepo.GetByParentId(PId);
        }
        // POST: api/M_Menus
        public Responses Post([FromBody]M_MenuViewModel entity)
        {
            Responses result = new Responses();
            if (ModelState.IsValid)
            {
                result = M_MenuRepo.Update(entity);
            }
            else
            {
                result.Success = false;
            }
            return result;
        }

        // PUT: api/M_Menus/5
        public Responses Put(int id, [FromBody]M_MenuViewModel entity)
        {
            entity.Id = id;
            Responses result = new Responses();
            if (ModelState.IsValid)
            {
                result = M_MenuRepo.Update(entity);
            }
            else
            {
                result.Success = false;
            }
            return result;
        }

        // DELETE: api/M_Menus/5
        public Responses Delete(int id)
        {
            return M_MenuRepo.Delete(id);
        }
    }
}
