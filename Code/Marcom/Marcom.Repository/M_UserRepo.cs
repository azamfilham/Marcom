using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class M_UserRepo
    {
        public static List<M_UserViewModel> Get()
        {
            List<M_UserViewModel> result = new List<M_UserViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from u in db.m_user
                          join e in db.m_employee on
                          u.m_employee_id equals e.id
                          join r in db.m_role on
                          u.m_role_id equals r.id
                          join c in db.m_company on
                          e.m_company_id equals c.id
                          where u.is_delete == false
                          select new M_UserViewModel
                          {
                              Id = u.id,
                              Username = u.username,
                              Password = u.password,   
                              MRoleId = u.m_role_id,                           
                              RoleName = r.name,
                              MEmployeeId = e.id,
                              FirstName = e.first_name,
                              LastName = e.last_name,
                              MCompanyId = c.id,
                              CompanyName = c.name,
                              CreatedBy = u.created_by,
                              CreatedDate = u.created_date,
                              IsDelete = u.is_delete
                          }).ToList();
            }
            return result;
        }

        public static M_UserViewModel GetById(int id)
        {
            M_UserViewModel result = new M_UserViewModel();
            using (var db = new MarcomContext())
            {
                result = (from u in db.m_user                          
                          join r in db.m_role on
                          u.m_role_id equals r.id
                          join e in db.m_employee on
                          u.m_employee_id equals e.id
                          join c in db.m_company on
                          e.m_company_id equals c.id
                          where u.id == id
                          select new M_UserViewModel
                          {
                              Id = u.id,
                              Username = u.username,
                              Password = u.password,
                              MRoleId = u.m_role_id,
                              RoleName = r.name,
                              MEmployeeId = e.id,
                              FirstName = e.first_name,
                              MCompanyId = c.id,
                              CompanyName = c.name,
                              CreatedBy = u.created_by,
                              CreatedDate = u.created_date,
                              IsDelete = false
                          }).FirstOrDefault();
            }
            return result;
        }

        //public static bool UserExist(string user)
        //{
        //    bool result = true;
        //    using (var db = new MarcomContext())
        //    {
        //        m_user us = db.m_user.Where(u => u.username == user).FirstOrDefault();
        //        if (us == null)
        //        {
        //            return result = false;
        //        }
        //        else
        //        {
        //            return result = true;
        //        }
        //    }
        //}

        public static Responses Update(M_UserViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        m_user mUser = db.m_user.Where(u => u.id == entity.Id).FirstOrDefault();
                        if (mUser != null)
                        {
                            mUser.username = entity.Username;
                            mUser.password = entity.Password;
                            mUser.m_employee_id = entity.MEmployeeId;
                            mUser.m_role_id = entity.MRoleId;
                            mUser.updated_by = "Admin";
                            mUser.updated_date = DateTime.Now;
                            mUser.is_delete = false;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        m_user mUser = new m_user();
                        mUser.username = entity.Username;
                        mUser.password = entity.Password;
                        mUser.m_employee_id = entity.MEmployeeId;
                        mUser.m_role_id = entity.MRoleId;           
                        mUser.created_by = "Admin";
                        mUser.created_date = DateTime.Now;
                        mUser.is_delete = false;
                        db.m_user.Add(mUser);
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
                    m_user mUser = db.m_user.Where(u => u.id == id).FirstOrDefault();
                    if (mUser != null)
                    {
                        mUser.is_delete = true;
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
