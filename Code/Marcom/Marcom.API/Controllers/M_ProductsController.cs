﻿using Marcom.Repository;
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
    public class M_ProductsController : ApiController
    {
        // GET: api/M_Products
        public IEnumerable<M_ProductViewModel> Get()
        {
            return M_ProductRepo.Get();
        }

        // GET: api/M_Products/5
        public M_ProductViewModel Get(int id)
        {
            return M_ProductRepo.GetById(id);
        }

        // POST: api/M_Products
        public Responses Post([FromBody]M_ProductViewModel entities)
        {
            entities.Code = M_ProductRepo.GetNewCode();
            return M_ProductRepo.update(entities);
        }

        // PUT: api/M_Products/5
        public Responses Put(int id, [FromBody]M_ProductViewModel entity)
        {
            entity.Id = id;
            return M_ProductRepo.update(entity);
        }

        // DELETE: api/M_Products/5
        public Responses Delete(int id)
        {
            return M_ProductRepo.Delete(id);
        }
    }
}
