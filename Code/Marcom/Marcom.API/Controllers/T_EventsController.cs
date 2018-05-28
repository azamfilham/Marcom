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
<<<<<<< HEAD
        public Responses Post([FromBody]T_EventViewModel entity) //bagian Add
        {

=======
        public Responses Post([FromBody]T_EventViewModel entity)
        {
>>>>>>> 9fa68a320bb1933c32d2a3bf22524c0ca4af5ce7
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
<<<<<<< HEAD
        public Responses Put(int id, [FromBody]T_EventViewModel entity) //Bagian Edit(Update)
        {
            entity.Id = id;
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

        // DELETE: api/T_Events/5
        public Responses Delete(int id) //Bagian Delete
=======
        public Responses Put(int id, [FromBody]T_EventViewModel entity)
        {
            entity.Id = id;
            return T_EventRepo.Update(entity);
        }

        // DELETE: api/T_Events/5
        [HttpDelete]
        public Responses Delete(int id)
>>>>>>> 9fa68a320bb1933c32d2a3bf22524c0ca4af5ce7
        {
            return T_EventRepo.Delete(id);
        }
    }

}
