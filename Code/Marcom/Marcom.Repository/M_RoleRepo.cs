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
    }
}