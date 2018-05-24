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
    public class T_EventsController : ApiController
    {
        // GET: api/T_Events
        public IEnumerable<T_EventViewModel> Get()
        {
            return T_EventRepo.Get();
        }

        // GET: api/T_Events/5
        public T_EventViewModel Get(int id)
        {
            return T_EventRepo.GetById(id);
        }

        // POST: api/T_Events
        public Responses Post([FromBody]T_EventViewModel entity)
        {
            Responses result = new Responses();
            if (ModelState.IsValid)
            {
                result = T_EventRepo.Update(entity);
            }
            else
            {
                result.Success = false;
            }
            return result;
        }

        // PUT: api/T_Events/5
        public Responses Put(int id, [FromBody]T_EventViewModel entity)
        {
            entity.Id = id;
            return T_EventRepo.Update(entity);
        }

        // DELETE: api/T_Events/5
        [HttpDelete]
        public Responses Delete(int id)
        {
            return T_EventRepo.Delete(id);
        }
    }
}
