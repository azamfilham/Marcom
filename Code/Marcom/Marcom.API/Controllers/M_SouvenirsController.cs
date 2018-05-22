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
    public class M_SouvenirsController : ApiController
    {
        // GET: api/M_Souvenirs
        public IEnumerable<M_SouvenirViewModel> Get()
        {
            return M_SouvenirRepo.Get();
        }

        // GET: api/M_Souvenirs/5
        public M_SouvenirViewModel Get(int id)
        {
            return M_SouvenirRepo.GetById(id);
        }

        // POST: api/M_Souvenirs
        public Responses Post([FromBody]M_SouvenirViewModel entity)
        {
            return M_SouvenirRepo.Update(entity);
        }

        // PUT: api/M_Souvenirs/5
        public Responses Put(int id, [FromBody]M_SouvenirViewModel entity)
        {
            entity.Id = id;
            return M_SouvenirRepo.Update(entity);
        }

        // DELETE: api/M_Souvenirs/5
        [HttpDelete]
        public Responses Delete(int id)
        {
            return M_SouvenirRepo.Delete(id);
        }
    }
}
