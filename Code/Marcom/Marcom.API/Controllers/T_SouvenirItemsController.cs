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
    public class T_SouvenirItemsController : ApiController
    {
        // GET: api/T_SouvenirItems
        public IEnumerable<T_SouvinerItemViewModel> Get()
        {
            return T_SouvinerItemRepo.Get();
        }

        // GET: api/T_SouvenirItems/5
        public T_SouvinerItemViewModel Get(int id)
        {
            return T_SouvinerItemRepo.GetById(id);
        }

        // POST: api/T_SouvenirItems
        public Responses Post([FromBody]T_SouvenirViewModel entity)
        {
            return T_SouvenirRepo.Update(entity);
        }

        // PUT: api/T_Souvenirs/5
        public Responses Put(int id, [FromBody]T_SouvenirViewModel entity)
        {
            entity.Id = id;
            return T_SouvenirRepo.Update(entity);
        }

        // DELETE: api/T_Souvenirs/5
        public void Delete(int id)
        {
        }
    }
}