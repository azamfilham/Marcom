﻿using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marcom.API.Controllers
{
    public class M_UnitsController : ApiController
    {
        // GET: api/M_Units
        public IEnumerable<M_UnitViewModel> Get()
        {
            return M_UnitRepo.Get();
        }

        // GET: api/M_Units/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/M_Units
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/M_Units/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/M_Units/5
        public void Delete(int id)
        {
        }
    }
}
