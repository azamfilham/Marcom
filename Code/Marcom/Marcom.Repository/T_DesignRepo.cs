using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class T_DesignRepo
    {
        public static string GetNewCode()
        {
            int newIncrement = 1;
            string newCode = string.Format("TRWODS{0}{1}{2}", DateTime.Now.Day.ToString("D2"), DateTime.Now.Month.ToString("D2"), DateTime.Now.ToString("yy"));
            using (var db = new MarcomContext())
            {
                var result = (from d in db.t_design
                              where d.code.Contains(newCode)
                              select new { tcode = d.code})
                              .OrderByDescending(o => o.tcode)
                              .FirstOrDefault();
                if (result != null)
                {
                    string rcode = result.tcode.ToString();
                    string c1 = rcode.Substring(0, 6);
                    string c2 = rcode.Substring(6, 6);
                    string c3 = rcode.Substring(12, 5);
                    newIncrement = int.Parse(c3) + 1;
                }
            }
            newCode += newIncrement.ToString("D5");
            string code = newCode.Replace(".", "");
            return code;
        }
		

        public static List<T_DesignViewModel> Get()
        {
            List<T_DesignViewModel> result = new List<T_DesignViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from d in db.t_design
                          join ev in db.t_event on
                          d.t_event_id equals ev.id
                          join e in db.m_employee on
                          d.request_by equals e.id
                          select new T_DesignViewModel
                          {
                              Id = d.id,
                              Code = d.code,
                              RequestBy = d.request_by,
                              FirstName = e.first_name,
                              LastName = e.last_name,
                              RequestDate = d.request_date,
                              AssignTo = d.assign_to,
                              Status = d.status,
                              IsDelete = d.is_delete,
                              CreatedBy = d.created_by,
                              CreatedDate = d.created_date
                          }).ToList();
            }
            return result;
        }

        public static T_DesignViewModel GetById(int id)
        {
            T_DesignViewModel result = new T_DesignViewModel();
            using (var db = new MarcomContext())
            {
                result = (from d in db.t_design
                          where d.id == id
                          select new T_DesignViewModel
                          {
                              Id = d.id,
                              Code = d.code,
                              TitleHeader = d.title_header,
                              RequestBy = d.request_by,
                              RequestDate = d.request_date,
                              AssignTo = d.assign_to,
                              Status = d.status,
                              Note = d.note,
                              IsDelete = d.is_delete,
                              CreatedBy = d.created_by,
                              CreatedDate = d.created_date
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(T_DesignViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        t_design design = db.t_design.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (design != null)
                        {
                            design.code = entity.Code;
                            design.t_event_id = entity.TEventId;
                            design.title_header = entity.TitleHeader;
                            design.request_by = entity.RequestBy;
                            design.request_date = entity.RequestDate;
                            design.assign_to = entity.AssignTo;
                            design.status = entity.Status;
                            design.note = entity.Note;
                            design.is_delete = false;
                            design.updated_by = "Ryan";
                            design.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        t_design design = new t_design();
                        design.code = entity.Code;
                        design.t_event_id = entity.TEventId;
                        design.title_header = entity.TitleHeader;
                        design.request_by = 6;
                        design.request_date = DateTime.Now;
                        design.assign_to = null;
                        design.status = 1;
                        design.note = entity.Note;
                        design.is_delete = false;
                        design.created_by = "Ryan";
                        design.created_date = DateTime.Now;
                        db.t_design.Add(design);
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
                    t_design design = db.t_design.Where(o => o.id == id).FirstOrDefault();
                    if (design != null)
                    {
                        design.is_delete = true;
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
