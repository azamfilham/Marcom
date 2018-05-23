using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class M_UnitRepo
    {
        public static List<M_UnitViewModel> Get()
        {
            List<M_UnitViewModel> result = new List<M_UnitViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from u in db.m_unit
                          select new M_UnitViewModel
                          {
                              Id = u.id,
                              Code = u.code,
                              Name = u.name,
                              Description = u.description,
                              CreatedBy = u.created_by,
                              CratedDate = u.created_date
                          }).ToList();
            }
            return result;
        }

        public static M_UnitViewModel GetById(int Id)
        {
            M_UnitViewModel result = new M_UnitViewModel();
            using (var db = new MarcomContext())    
            {
                result = (from u in db.m_unit
                          where u.id == Id
                          select new M_UnitViewModel
                          {
                              Id = u.id,
                              Code = u.code,
                              Name = u.name,
                              Description = u.description,
                              CreatedBy = u.created_by,
                              CratedDate = u.created_date
                          }).FirstOrDefault();

            }
            return result;
        }

        public static Responses update(M_UnitViewModel entity)
        {
            Responses result = new Responses();
            
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        m_unit m_unit = db.m_unit.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (m_unit != null)
                        {
                            m_unit.code = entity.Code;
                            m_unit.name = entity.Name;
                            m_unit.description = entity.Description;
                            m_unit.is_delete = entity.IsDelete;        
                            m_unit.updated_by = "DavidAgung";
                            m_unit.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }

                    }

                    else
                    {
                        m_unit M_unit = new m_unit();
                        M_unit.code = entity.Code;
                        M_unit.name = entity.Name;
                        M_unit.description = entity.Description;
                        M_unit.is_delete = entity.IsDelete;
                        M_unit.created_by = "David";
                        M_unit.created_date = DateTime.Now;
                        db.m_unit.Add(M_unit);
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

        public static Responses Delete(int Id)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    m_unit m_unit = db.m_unit.Where(o => o.id == Id).FirstOrDefault();

                    if (m_unit != null)
                    {
                        db.m_unit.Remove(m_unit);
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

    public class MUResponse : Responses
    {
        public string Reference { get; set; }
    }

}

