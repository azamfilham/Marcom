using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class M_MenuAccessRepo
    {
        public static Responses Update(M_MenuAccessViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        m_menu_access mAccess = db.m_menu_access.Where(o => o.id == entity.Id).FirstOrDefault();
                        //if (role != null)
                        //{
                        //    role.code = entity.Code;
                        //    role.name = entity.Name;
                        //    role.description = entity.Description;
                        //    role.is_delete = entity.IsDelete;
                        //    role.updated_by = "Freeska";
                        //    role.updated_date = DateTime.Now;
                        //    db.SaveChanges();
                        //}
                    }
                    else
                    {
                        m_menu_access mAccess = new m_menu_access();
                        mAccess.m_menu_id = entity.MMenuId;
                        mAccess.m_role_id = entity.MRoleId;
                        mAccess.is_delete = entity.IsDelete;
                        mAccess.created_by = "Admin";
                        mAccess.created_date = DateTime.Now;

                        db.m_menu_access.Add(mAccess);
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
