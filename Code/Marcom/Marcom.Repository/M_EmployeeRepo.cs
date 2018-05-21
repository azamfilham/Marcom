using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class M_EmployeeRepo
    {
        public static List<M_EmployeeViewModel> Get()
        {
            List<M_EmployeeViewModel> result = new List<M_EmployeeViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from e in db.m_employee
                          join c in db.m_company on
                          e.m_company_id equals c.id
                          select new M_EmployeeViewModel
                          {
                              Id = e.id,
                              EmployeeNumber = e.employee_number,
                              FirstName = e.first_name,
                              LastName = e.last_name,
                              MCompanyName = c.name,
                              Email = e.email,
                              IsDelete = e.is_delete
                          }).ToList();
            }
            return result;
        }

        public static M_EmployeeViewModel GetById(int id)
        {
            M_EmployeeViewModel result = new M_EmployeeViewModel();
            using (var db = new MarcomContext())
            {
                result = (from e in db.m_employee
                          join c in db.m_company on
                          e.m_company_id equals c.id
                          where e.id == id
                          select new M_EmployeeViewModel
                          {
                              Id = e.id,
                              EmployeeNumber = e.employee_number,
                              FirstName = e.first_name,
                              LastName = e.last_name,
                              MCompanyName = c.name,
                              Email = e.email,
                              IsDelete = e.is_delete
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(M_EmployeeViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        m_employee employee = db.m_employee.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (employee != null)
                        {
                            employee.id = entity.Id;
                            employee.employee_number = entity.EmployeeNumber;
                            employee.first_name = entity.FirstName;
                            employee.last_name = entity.LastName;
                            employee.m_company_id = entity.MCompanyId;
                            employee.email = entity.Email;
                            employee.is_delete = entity.IsDelete;
                            employee.updated_by = "Ryan";
                            employee.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        m_employee employee = new m_employee();
                        employee.id = entity.Id;
                        employee.employee_number = entity.EmployeeNumber;
                        employee.first_name = entity.FirstName;
                        employee.last_name = entity.LastName;
                        employee.m_company_id = entity.MCompanyId;
                        employee.email = entity.Email;
                        employee.is_delete = false;
                        employee.created_by = "Ryan";
                        employee.created_date = DateTime.Now;
                        db.m_employee.Add(employee);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }

        public static Responses Delete(int id)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    m_employee employee = db.m_employee.Where(o => o.id == id).FirstOrDefault();
                    if (employee != null)
                    {
                        employee.is_delete = true;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }
    }
}