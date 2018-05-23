using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Marcom.API.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class M_UnitsController : ApiController
    {
        
        // GET: api/M_Units
        public IEnumerable<M_UnitViewModel> Get()
        {
            return M_UnitRepo.Get();
        }

        // GET: api/M_Units/5
        public M_UnitViewModel Get(int id)
        {
            return M_UnitRepo.GetById(id);
        }

        // POST: api/M_Units
        public Responses Post([FromBody]M_UnitViewModel entity) //bagian Add
        {

            Responses result = new Responses();
            if (ModelState.IsValid)
            {
                result = M_UnitRepo.update(entity);
            }
            else
            {
                result.Success = false;
            }
            return result;
        }

        // PUT: api/M_Units/5
        public Responses Put(int id, [FromBody]M_UnitViewModel entity) //Bagian Edit(Update)
        {
            entity.Id = id;
            Responses result = new Responses();
            if (ModelState.IsValid)
            {
                result = M_UnitRepo.update(entity);
            }
            else
            {
                result.Success = false;
            }
            return result;
          
        }

        // DELETE: api/M_Units/5
        public Responses Delete(int id) //Bagian Delete
        {
            return M_UnitRepo.Delete(id);
        }
    }
}
