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
    public class T_DesignItemsController : ApiController
    {
        // GET: api/T_DesignItems
        public IEnumerable<T_DesignItemViewModel> Get()
        {
            return T_DesignItemRepo.Get();
        }

        // GET: api/T_DesignItems/5
        public T_DesignItemViewModel Get(int id)
        {
            return T_DesignItemRepo.GetById(id);
        }

        // POST: api/T_DesignItems
        public Responses Post([FromBody]T_DesignItemViewModel entity)
        {
            return T_DesignItemRepo.Update(entity);
        }

        // PUT: api/T_DesignItems/5
        public Responses Put(int id, [FromBody]T_DesignItemViewModel entity)
        {
            entity.Id = id;
            return T_DesignItemRepo.Update(entity);
        }

        // DELETE: api/T_DesignItems/5
        public Responses Delete(int id)
        {
            return T_DesignItemRepo.Delete(id);
        }
    }
}
