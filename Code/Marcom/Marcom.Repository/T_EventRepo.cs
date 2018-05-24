using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class T_EventRepo
    {
        public static List<T_EventViewModel> Get()
        {
            List<T_EventViewModel> result = new List<T_EventViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from e in db.t_event
                          select new T_EventViewModel
                          {
                              Id = e.id,
                              Code = e.code,
                              EventName = e.event_name,
                              StartDate = e.start_date,
                              EndDate = e.end_date,
                              Place = e.place,
                              Budget = e.budget,
                              RequestBy = e.request_by,
                              RequestDate = e.request_date,
                              ApprovedBy = e.approved_by,
                              ApprovedDate = e.approved_date,
                              AssignTo = e.assign_to,
                              ClosedDate = e.closed_date,
                              Note = e.note,
                              Status = e.status,
                              RejectReason = e.reject_reason,
                              IsDelete = e.is_delete,
                              CreatedBy = e.created_by,
                              CreatedDate = e.created_date,
                              UpdatedBy = e.updated_by,
                              UpdatedDate = e.updated_date
                          }).ToList();
            }
            return result;
        }
        public static T_EventViewModel GetById(int id)
        {
            T_EventViewModel result = new T_EventViewModel();
            using (var db = new MarcomContext())
            {
                result = (from e in db.t_event
                          where e.id == id
                          select new T_EventViewModel
                          {
                              Id = e.id,
                              Code = e.code,
                              EventName = e.event_name,
                              StartDate = e.start_date,
                              EndDate = e.end_date,
                              Place = e.place,
                              Budget = e.budget,
                              RequestBy = e.request_by,
                              RequestDate = e.request_date,
                              ApprovedBy = e.approved_by,
                              ApprovedDate = e.approved_date,
                              AssignTo = e.assign_to,
                              ClosedDate = e.closed_date,
                              Note = e.note,
                              Status = e.status,
                              RejectReason = e.reject_reason,
                              IsDelete = e.is_delete,
                              CreatedBy = e.created_by,
                              CreatedDate = e.created_date,
                              UpdatedBy = e.updated_by,
                              UpdatedDate = e.updated_date
                          }).FirstOrDefault();
            }
            return result;
        }
        public static Responses Update(T_EventViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        t_event ev = db.t_event.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (ev != null)
                        {
                            ev.code = entity.Code;
                            ev.event_name = entity.EventName;
                            ev.start_date = entity.StartDate;
                            ev.end_date = entity.EndDate;
                            ev.place = entity.Place;
                            ev.budget = entity.Budget;
                            ev.request_by = entity.RequestBy;
                            ev.request_date = entity.RequestDate;
                            ev.approved_by = entity.ApprovedBy;
                            ev.approved_date = entity.ApprovedDate;
                            ev.assign_to = entity.AssignTo;
                            ev.closed_date = entity.ClosedDate;
                            ev.note = entity.Note;
                            ev.status = entity.Status;
                            ev.reject_reason = entity.RejectReason;
                            ev.is_delete = entity.IsDelete;
                            ev.updated_by = "Admin";
                            ev.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        t_event ev = new t_event();
                        ev.code = entity.Code;
                        ev.event_name = entity.EventName;
                        ev.start_date = entity.StartDate;
                        ev.end_date = entity.EndDate;
                        ev.place = entity.Place;
                        ev.budget = entity.Budget;
                        ev.request_by = entity.RequestBy;
                        ev.request_date = entity.RequestDate;
                        ev.approved_by = entity.ApprovedBy;
                        ev.approved_date = entity.ApprovedDate;
                        ev.assign_to = entity.AssignTo;
                        ev.closed_date = entity.ClosedDate;
                        ev.note = entity.Note;
                        ev.status = entity.Status;
                        ev.reject_reason = entity.RejectReason;
                        ev.is_delete = entity.IsDelete;
                        ev.created_by = "Admin";
                        ev.created_date = DateTime.Now;
                        db.t_event.Add(ev);
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
                    t_event ev = db.t_event.Where(o => o.id == id).FirstOrDefault();
                    if (ev != null)
                    {
                        ev.is_delete = true;
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
