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
    public class T_DesignsController : ApiController
    {
        // GET: api/T_Designs
        public IEnumerable<T_DesignViewModel> Get()
        {
            return T_DesignRepo.Get();
        }

        // GET: api/T_Designs/5
        public T_DesignViewModel Get(int id)
        {
            return T_DesignRepo.GetById(id);
        }

        // POST: api/T_Designs
        public Responses Post([FromBody]T_DesignViewModel entity)
        {
            //Responses result = new Responses();
            //if (ModelState.IsValid)
            //{
                return T_DesignRepo.Update(entity);
            //}
            //else
            //{
            //    result.Success = false;
            //}
            //return result;
        }

        // PUT: api/T_Designs/5
        public Responses Put(int id, [FromBody]T_DesignViewModel entity)
        {
            entity.Id = id;
            Responses result = new Responses();
            if (ModelState.IsValid)
            {
                result = T_DesignRepo.Update(entity);
            }
            else
            {
                result.Success = false;
            }
            return result;
        }

        // DELETE: api/T_Designs/5
        public Responses Delete(int id)
        {
            return T_DesignRepo.Delete(id);
        }
    }
}
