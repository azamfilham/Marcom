﻿using Marcom.DataModel;
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
        public static string GetNewCode()
        {
            int newIncrement = 1;
            string newCode = string.Format("TRWOEV{0}{1}{2}.", DateTime.Now.Day.ToString("D2"), DateTime.Now.Month.ToString("D2"), DateTime.Now.ToString("yy") );
            using (var db = new MarcomContext())
            {
                var result = (from ev in db.t_event
                              where ev.code.Contains(newCode)
                              select new { code = ev.code })
                              .OrderByDescending(o => o.code)
                              .FirstOrDefault();
                if (result != null)
                {
                    string[] oldCode = result.code.Split('.'); //SplitCode(result.code);
                    newIncrement = int.Parse(oldCode[3]) + 1;
                }

            }
            newCode += newIncrement.ToString("D5");
            string code = newCode.Replace(".", "");
            return code;
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

        public static List<T_EventViewModel> Get()
        {
            List<T_EventViewModel> result = new List<T_EventViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from e in db.t_event
                          join em in db.m_employee on
                          e.request_by equals em.id
                          where e.is_delete == false
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
                              FirstName = em.first_name,
                              LastName = em.last_name,
                              
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
                          join em in db.m_employee on
                          e.request_by equals em.id
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
                              FirstName = em.first_name,
                              LastName = em.last_name,

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
                            ev.id = entity.Id;
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
                        ev.id = entity.Id;
                        ev.code = GetNewCode();
                        ev.event_name = entity.EventName;
                        ev.start_date = entity.StartDate;
                        ev.end_date = entity.EndDate;
                        ev.place = entity.Place;
                        ev.budget = entity.Budget;
                        ev.request_by = entity.RequestBy;
                        ev.request_date = DateTime.Now;
                        ev.approved_by = entity.ApprovedBy;
                        ev.approved_date = entity.ApprovedDate;
                        ev.assign_to = entity.AssignTo;
                        ev.closed_date = entity.ClosedDate;
                        ev.note = entity.Note;
                        ev.status = 1;
                        ev.reject_reason = entity.RejectReason;
                        ev.is_delete = false;
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
