using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class T_PromotionRepo
    {
        public static List<T_PromotionViewModel> Get()
        {
            List<T_PromotionViewModel> result = new List<T_PromotionViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from p in db.t_promotion
                          join ev in db.t_event 
                          on p.t_event_id equals ev.id
                          join e in db.m_employee
                          on p.request_by equals e.id
                          join em in db.m_employee
                          on p.assign_to equals em.id
                          where p.is_delete == false
                          select new T_PromotionViewModel
                          {
                              Id = p.id,
                              Code = p.code,
                              FlagDesign = p.flag_design,
                              TEventId = p.t_event_id,
                              TEventCode = ev.code,
                              TDesignId = p.t_design_id,
                              RequestBy = p.request_by,
                              RFirstName = e.first_name,
                              RLastName = e.last_name,
                              RequestDate = p.request_date,
                              ApprovedBy = p.approved_by,
                              ApprovedDate = p.approved_date,
                              AssignTo = p.assign_to,
                              AFirstName = em.first_name,
                              ALastName = em.last_name,
                              CloseDate = p.close_date,
                              Note = p.note,
                              Status = p.status,
                              RejectReason = p.reject_reason,
                              IsDelete = p.is_delete,
                              CreatedBy = p.created_by,
                              CreatedDate = p.created_date,
                              UpdatedBy = p.updated_by,
                              UpdatedDate = p.updated_date,
                          }).ToList();
            }
            return result;
        }

        public static T_PromotionViewModel GetById(int id)
        {
            T_PromotionViewModel result = new T_PromotionViewModel();
            using (var db = new MarcomContext())
            {
                result = (from p in db.t_promotion
                          join e in db.t_event
                         on p.t_event_id equals e.id
                          where p.id == id
                          select new T_PromotionViewModel
                          {
                              Id = p.id,
                              Code = p.code,
                              FlagDesign = p.flag_design,
                              TEventId = p.t_event_id,
                              TEventCode = e.code,
                              TDesignId = p.t_design_id,
                              RequestBy = p.request_by,
                              RequestDate = p.request_date,
                              ApprovedBy = p.approved_by,
                              ApprovedDate = p.approved_date,
                              AssignTo = p.assign_to,
                              CloseDate = p.close_date,
                              Note = p.note,
                              Status = p.status,
                              RejectReason = p.reject_reason,
                              IsDelete = p.is_delete,
                              CreatedBy = p.created_by,
                              CreatedDate = p.created_date,
                              UpdatedBy = p.updated_by,
                              UpdatedDate = p.updated_date
                          }).FirstOrDefault();
            }
            return result;
        }

        public static T_MarketingPromotionViewModel GetByEventandDesign(int EventId,int DesignId)
        {
            T_MarketingPromotionViewModel result = new T_MarketingPromotionViewModel();
            using (var db = new MarcomContext())
            {
                result = (from p in db.t_promotion
                          join e in db.t_event
                          on p.t_event_id equals e.id
                          join d in db.t_design
                          on e.id equals d.t_event_id
                          join em in db.m_employee
                          on d.request_by equals em.id
                          where d.id == DesignId && d.t_event_id == EventId
                          select new T_MarketingPromotionViewModel
                          {
                              TEventId = e.id,
                              TDesignId = d.id,
                              TEventCode = e.code,
                              RequestBy = p.request_by,
                              RequestDate = DateTime.Now,
                              TDesignCode = d.code,
                              TDesignTitleHeader = d.title_header,
                              TDesignRequestBy = d.request_by,
                              DFirstName = em.first_name,
                              DLastName = em.last_name,
                              TDesignRequestDate = d.request_date,
                              TDesignNote = d.note
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(T_PromotionViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        t_promotion promotion = db.t_promotion.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (promotion != null)
                        {
                            t_promotion p = new t_promotion();
                            p.id = entity.Id;
                            p.code = entity.Code;
                            p.flag_design = entity.FlagDesign;
                            p.t_event_id = entity.TEventId;
                            p.t_design_id = entity.TDesignId;
                            p.request_by = entity.RequestBy;
                            p.request_date = entity.RequestDate;
                            p.approved_by = entity.ApprovedBy;
                            p.approved_date = entity.ApprovedDate;
                            p.assign_to = entity.AssignTo;
                            p.close_date = entity.CloseDate;
                            p.note = entity.Note;
                            p.status = entity.Status;
                            p.reject_reason = entity.RejectReason;
                            p.is_delete = entity.IsDelete;
                            p.updated_by = "Freeska";
                            p.updated_date = DateTime.Now;

                            foreach (var item in entity.DetailItem)
                            {
                                t_promotion_item pItem = db.t_promotion_item.Where(o => o.t_promotion_id == entity.Id).FirstOrDefault();
                                if (pItem != null)
                                {
                                    t_promotion_item pi = new t_promotion_item();
                                    pi.id = item.Id;
                                    pi.t_promotion_id = entity.Id;
                                    pi.t_design_item_id = item.TDesignItemId;
                                    pi.m_product_id = item.MProductId;
                                    pi.title = item.Title;
                                    pi.request_pic = item.RequestPic;
                                    pi.start_date = item.StartDate;
                                    pi.end_date = item.EndDate;
                                    pi.request_due_date = item.RequestDueDate;
                                    pi.qty = item.Qty;
                                    pi.todo = item.ToDo;
                                    pi.note = item.Note;
                                    pi.is_delete = item.isDelete;
                                    pi.updated_by = "Freeska";
                                    pi.updated_date = DateTime.Now;
                                }                                
                            }
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        t_promotion p = new t_promotion();
                        p.id = entity.Id;                
                        p.code = "TRWOMP0000012";
                        p.flag_design = "1";
                        p.t_event_id = entity.TEventId;
                        p.t_design_id = entity.TDesignId;
                        p.request_by = entity.RequestBy;
                        p.request_date = entity.RequestDate;
                        p.approved_by = entity.ApprovedBy;
                        p.approved_date = entity.ApprovedDate;
                        p.assign_to = entity.AssignTo;
                        p.close_date = entity.CloseDate;
                        p.note = entity.Note;
                        p.status = entity.Status;
                        p.reject_reason = entity.RejectReason;
                        p.is_delete = entity.IsDelete;
                        p.created_by = "Freeska";
                        p.created_date = DateTime.Now;
                        foreach (var item in entity.DetailItem)
                        {
                            t_promotion_item pi = new t_promotion_item();
                            pi.id = item.Id;
                            pi.t_promotion_id = entity.Id;
                            pi.t_design_item_id = item.TDesignItemId;
                            pi.m_product_id = item.MProductId;
                            pi.title = item.Title;
                            pi.request_pic = 2;
                            pi.start_date = item.StartDate;
                            pi.end_date = item.EndDate;
                            pi.request_due_date = item.RequestDueDate;
                            pi.qty = item.Qty;
                            pi.todo = item.ToDo;
                            pi.note = item.Note;
                            pi.is_delete = item.isDelete;
                            pi.created_by = "Freeska";
                            pi.created_date = DateTime.Now;
                            db.t_promotion_item.Add(pi);
                        }

                        db.t_promotion.Add(p);
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
                    t_promotion promotion = db.t_promotion.Where(o => o.id == id).FirstOrDefault();
                    if (promotion != null)
                    {
                        promotion.is_delete = true;
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
            string newCode = string.Format("TRWOMP");
            using (var db = new MarcomContext())
            {
                var result = (from r in db.t_promotion
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

