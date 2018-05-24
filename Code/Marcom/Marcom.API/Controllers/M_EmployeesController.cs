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

        [HttpGet]
        [Route("~/api/M_Employees/Employee")]
        public IEnumerable<M_EmployeeViewModel> GetByEmId()
        {
            return M_EmployeeRepo.GetByEmployId();
        }

        // POST: api/M_Employees
        public Responses Post([FromBody]M_EmployeeViewModel entity)
        {
            Responses result = new Responses();
            if (ModelState.IsValid)
            {
                result = M_EmployeeRepo.Update(entity);
            }
            else
            {
                result.Success = false;
            }
            return result;
        }

        // PUT: api/M_Employees/5
        public Responses Put(int id, [FromBody]M_EmployeeViewModel entity)
        {
            entity.Id = id;
            Responses result = new Responses();
            if (ModelState.IsValid)
            {
                result = M_EmployeeRepo.Update(entity);
            }
            else
            {
                result.Success = false;
            }
            return result;
        }

        // DELETE: api/M_Employees/5
        public Responses Delete(int id)
        {
            return M_EmployeeRepo.Delete(id);
        }
    }
}
