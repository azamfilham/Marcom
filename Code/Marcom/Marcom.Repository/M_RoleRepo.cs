using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class M_RoleRepo
    {
        public static List<M_RoleViewModel> Get()
        {
            List<M_RoleViewModel> result = new List<M_RoleViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from r in db.m_role
                          where r.is_delete == false
                          select new M_RoleViewModel
                          {
                              Id = r.id,
                              Code = r.code,
                              Name = r.name,
                              Description = r.description,
                              IsDelete = r.is_delete,
                              CreatedBy = r.created_by,
                              CreatedDate = r.created_date,
                              UpdatedBy = r.updated_by,
                              UpdatedDate = r.updated_date
                          }).ToList();
            }
            return result;
        }

        public static M_RoleViewModel GetById(int id)
        {
            M_RoleViewModel result = new M_RoleViewModel();
            using (var db = new MarcomContext())
            {
                result = (from r in db.m_role
                          where r.id == id
                          select new M_RoleViewModel
                          {
                              Id = r.id,
                              Code = r.code,
                              Name = r.name,
                              Description = r.description,
                              IsDelete = r.is_delete,
                              CreatedBy = r.created_by,
                              CreatedDate = r.created_date,
                              UpdatedBy = r.updated_by,
                              UpdatedDate = r.updated_date
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(M_RoleViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        m_role role = db.m_role.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (role != null)
                        {
                            role.code = entity.Code;
                            role.name = entity.Name;
                            role.description = entity.Description;
                            role.is_delete = entity.IsDelete;
                            role.updated_by = "Freeska";
                            role.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        m_role role = new m_role();
                        role.code = entity.Code;
                        role.name = entity.Name;
                        role.description = entity.Description;
                        role.is_delete = entity.IsDelete;
                        role.created_by = "Freeska";
                        role.created_date = DateTime.Now;
                        db.m_role.Add(role);
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
                    m_role role = db.m_role.Where(o => o.id == id).FirstOrDefault();
                    if (role != null)
                    {
                        role.is_delete = true;
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

        public static string GetNewCode()
        {
            

            int newIncrement = 1;
            string newCode = string.Format("RO");
            using (var db = new MarcomContext())
            {
                var result = (from r in db.m_role
                              where r.code.Contains(newCode)
                              select new { code = r.code })
                              .OrderByDescending(o => o.code)
                              .FirstOrDefault();
                if (result != null)
                {
                    string[] oldCode = SplitCode(result.code);
                    newIncrement = int.Parse(oldCode[0]) + 1;
                }

            }
            newCode += newIncrement.ToString("D4");
            return newCode;
        }

        public static string[] SplitCode(string data)
        {
            string numbers = "";
            string alpha = "";
            foreach (char c in data)
            {
                if (Char.IsDigit(c))
                {
                    numbers = numbers + c;
                }
                else if (Char.IsLetter(c))
                {
                    alpha = alpha + c;
                }
            }
            return new string[] { numbers, alpha };
        }
    }
}
