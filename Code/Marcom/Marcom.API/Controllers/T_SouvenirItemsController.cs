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
        public void Post([FromBody]string value)
        {
        }
		
		[HttpGet]
        [Route("~/api/T_SouvenirItems/TSouvId/{id}")]
        public IEnumerable<T_SouvinerItemViewModel> GetBySouvId(int id)
        {
            return T_SouvinerItemRepo.GetBySouvId(id);
        }

        // PUT: api/T_SouvenirItems/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/T_SouvenirItems/5
        public void Delete(int id)
        {
        }
    }
}
