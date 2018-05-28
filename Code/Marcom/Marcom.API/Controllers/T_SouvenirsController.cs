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
    public class T_SouvenirsController : ApiController
    {
        // GET: api/T_Souvenirs
        public IEnumerable<T_SouvenirViewModel> Get()
        {
            return T_SouvenirRepo.Get();
        }

        // GET: api/T_Souvenirs/5
        public T_SouvenirViewModel Get(int id)
        {
            return T_SouvenirRepo.GetById(id);
        }

        // POST: api/T_Souvenirs
        public Responses Post([FromBody]T_SouvenirViewModel entity)
        {
            entity.Code = T_SouvenirRepo.GetNewCode();
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
