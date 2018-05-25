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
        public static string GetNewCode()
        {
            int newIncrement = 1;
            string newCode = string.Format("{0}.{1}.{2}.", DateTime.Now.ToString("yy"), DateTime.Now.Month.ToString("D2"), DateTime.Now.Day.ToString("D2"));
            using (var db = new MarcomContext())
            {
                var result = (from e in db.m_employee
                              where e.employee_number.Contains(newCode)
                              select new { code = e.employee_number })
                              .OrderByDescending(o => o.code)
                              .FirstOrDefault();
                if (result != null)
                {
                    string[] oldCode = result.code.Split('.');
                    newIncrement = int.Parse(oldCode[3]) + 1;
                }

            }
            newCode += newIncrement.ToString("D2");
            return newCode;
        }

        //public static string[] SplitCode(string data)
        //{
        //    string numbers = "";
        //    string alpha = "";
        //    foreach (char c in data)
        //    {
        //        if (Char.IsDigit(c))
        //        {
        //            numbers = numbers + c;
        //        }
        //        else if (Char.IsLetter(c))
        //        {
        //            alpha = alpha + c;
        //        }
        //    }
        //    return new string[] { numbers, alpha };
        //}
        public static List<M_EmployeeViewModel> Get()
        {
            List<M_EmployeeViewModel> result = new List<M_EmployeeViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from e in db.m_employee
                          join c in db.m_company on
                          e.m_company_id equals c.id
                          where e.is_delete == false
                          select new M_EmployeeViewModel
                          {
                              Id = e.id,
                              EmployeeNumber = e.employee_number,
                              FirstName = e.first_name,
                              LastName = e.last_name,
                              MCompanyId = c.id,
                              MCompanyName = c.name,
                              Email = e.email,
                              CreatedBy = e.created_by,
                              CreatedDate = e.created_date,
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
                              MCompanyId = c.id,
                              MCompanyName = c.name,
                              Email = e.email,
                              IsDelete = e.is_delete
                          }).FirstOrDefault();
            }
            return result;
        }

        public static List<M_EmployeeViewModel> GetByEmployId()
        {
            List<M_EmployeeViewModel> result = new List<M_EmployeeViewModel>();
            using (var db = new MarcomContext())
            {
                {
                    result = (from e in db.m_employee
                              join u in db.m_user on
                              e.id equals u.m_employee_id
                              into temp from x in temp.DefaultIfEmpty() //e.id  equals  u.m_employee_id //u.is_delete == 0
                              where temp.Count() == 0
                              select new M_EmployeeViewModel
                              {
                                  Id = e.id,
                                   //= (x.m_employee_id == null? "null" : x.m_employee_id),
                                  FirstName = e.first_name,
                                  LastName = e.last_name,
                                  IsDelete = false
                              }).ToList();
                }
            }
            return result;
        }

        public static List<M_EmployeeViewModel> GetByEmployeId(int id)
        {
            List<M_EmployeeViewModel> result = new List<M_EmployeeViewModel>();
            using (var db = new MarcomContext())
            {
                {
                    result = (from e in db.m_employee
                              join u in db.m_user on
                              e.id equals u.m_employee_id
                              into temp
                              from x in temp.DefaultIfEmpty() //e.id  equals  u.m_employee_id //u.is_delete == 0
                              where temp.Count() == 0 || e.id == id
                              select new M_EmployeeViewModel
                              {
                                  Id = e.id,
                                  //= (x.m_employee_id == null? "null" : x.m_employee_id),
                                  FirstName = e.first_name,
                                  LastName = e.last_name,
                                  IsDelete = false
                              }).ToList();
                }
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
                        employee.employee_number = GetNewCode();
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