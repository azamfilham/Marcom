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
        public Responses Post([FromBody]M_EmployeeViewModel entity)
        {
            return M_EmployeeRepo.Update(entity);
        }

        // PUT: api/M_Employees/5
        public Responses Put(int id, [FromBody]M_EmployeeViewModel entity)
        {
            entity.Id = id;
            return M_EmployeeRepo.Update(entity);
        }

        // DELETE: api/M_Employees/5
        public Responses Delete(int id)
        {
            return M_EmployeeRepo.Delete(id);
        }
    }
}
