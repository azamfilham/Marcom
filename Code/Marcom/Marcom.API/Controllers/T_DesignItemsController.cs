﻿using System;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/T_DesignItems/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/T_DesignItems
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/T_DesignItems/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/T_DesignItems/5
        public void Delete(int id)
        {
        }
    }
}
