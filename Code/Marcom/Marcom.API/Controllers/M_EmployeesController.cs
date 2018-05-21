using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Marcom.ViewModel;
using Marcom.Repository;

namespace Marcom.API.Controllers
{
    public class M_EmployeesController : ApiController
    {
        // GET: api/M_Employees
        public IEnumerable<M_EmployeeViewModel> Get()
        {
            return M_EmployeeRepo.Get();
        }

        // GET: api/M_Employees/5
        public M_EmployeeViewModel Get(int id)
        {
            return M_EmployeeRepo.GetById(id);
        }

        // POST: api/M_Employees
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/M_Employees/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/M_Employees/5
        public void Delete(int id)
        {
        }
    }
}
