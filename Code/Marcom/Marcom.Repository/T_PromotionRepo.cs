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
                result = (from e in db.t_event
                          join d in db.t_design
                          on e.id equals d.t_event_id
                          where d.id == DesignId && d.t_event_id == EventId
                          select new T_MarketingPromotionViewModel
                          {
                              TEventCode = e.code,
                              RequestBy = d.request_by,
                              RequestDate = DateTime.Now,
                              TDesignCode = d.code,
                              TDesignTitleHeader = d.title_header,
                              TDesignRequestBy = d.request_by,
                              TDesignRequestDate = d.request_date,
                              TDesignNote = d.note
                          }).FirstOrDefault();
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

