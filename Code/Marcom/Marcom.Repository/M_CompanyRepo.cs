using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class M_CompanyRepo
    {
        public static List<M_CompanyViewModel> Get()
        {
            List<M_CompanyViewModel> result = new List<M_CompanyViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from c in db.m_company
                          select new M_CompanyViewModel
                          {
                              Id = c.id,
                              Code = c.code,
                              Name = c.name,
                              Address = c.address,
                              Phone = c.phone,
                              Email = c.email,
                              IsDelete = c.is_delete,
                              CreatedBy = c.created_by,
                              CreatedDate = c.created_date,
                              UpdatedBy = c.updated_by,
                              UpdatedDate = c.updated_date
                          }).ToList();
            }
            return result;
        }

        public static M_CompanyViewModel GetById(int id)
        {
            M_CompanyViewModel result = new M_CompanyViewModel();
            using (var db = new MarcomContext())
            {
                result = (from c in db.m_company
                          where c.id == id
                          select new M_CompanyViewModel
                          {
                              Id = c.id,
                              Code = c.code,
                              Name = c.name,
                              Address = c.address,
                              Phone = c.phone,
                              Email = c.email,
                              IsDelete = c.is_delete,
                              CreatedBy = c.created_by,
                              CreatedDate = c.created_date,
                              UpdatedBy = c.updated_by,
                              UpdatedDate = c.updated_date
                          }).FirstOrDefault();
            }
            return result;
        }
        public static Responses Update(M_CompanyViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        m_company company = db.m_company.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (company != null)
                        {
                            company.code = entity.Code;
                            company.name = entity.Name;
                            company.address = entity.Address;
                            company.phone = entity.Phone;
                            company.email = entity.Email;
                            company.is_delete = entity.IsDelete;
                            company.updated_by = "Admin";
                            company.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        m_company company = new m_company();
                        company.code = entity.Code;
                        company.name = entity.Name;
                        company.address = entity.Address;
                        company.phone = entity.Phone;
                        company.email = entity.Email;
                        company.is_delete = entity.IsDelete;
                        company.created_by = "Admin";
                        company.created_date = DateTime.Now;
                        db.m_company.Add(company);
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