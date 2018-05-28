using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class T_SouvinerItemRepo
    {

        public static List<T_SouvinerItemViewModel> Get()
        {
            List<T_SouvinerItemViewModel> result = new List<T_SouvinerItemViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from tsi in db.t_souvenir_item
                          join ts in db.t_souvenir on
                          tsi.t_souvenir_id equals ts.id
                          join ms in db.m_souvenir on
                          tsi.m_souvenir_id equals ms.id
                          select new T_SouvinerItemViewModel
                          {
                              Id = tsi.id,

                              TransactionCode = ts.code,// Table t_souvenir_item
                              RequestBy = ts.request_by,
                              RequestDate = ts.request_date,
                              DueDate = ts.request_due_date,

                              Qty = tsi.qty,
                              QtySettlement = tsi.qty_settlement,
                              Note = tsi.note,
                              IsDelete = tsi.is_delete,
                              CreatedBy = tsi.created_by,
                              CreatedDate = tsi.created_date,
                              UpdatedBy = tsi.updated_by,
                              UpdatedDate = tsi.updated_date,
                          }).ToList();
            }
            return result;
        }

        public static T_SouvinerItemViewModel GetById(int Id)
        {
            T_SouvinerItemViewModel result = new T_SouvinerItemViewModel();
            using (var db = new MarcomContext())
            {
                result = (from tsi in db.t_souvenir_item
                          join ts in db.t_souvenir on
                          tsi.t_souvenir_id equals ts.id
                          join ms in db.m_souvenir on
                          tsi.m_souvenir_id equals ms.id
                          join tev in db.t_event on
                          ts.id equals tev.id
                          where tsi.id == Id
                          select new T_SouvinerItemViewModel
                          {
                              Id = tsi.id,
                              TransactionCode = ts.code,
                              EvenCode = tev.code,
                              RequestBy = ts.request_by,
                              RequestDate = ts.request_date,
                              DueDate = ts.request_due_date,

                              Note = tsi.note,
                              SouvenirName = ms.name,
                              Qty = tsi.qty,
                              Note2 = ts.note,        
                              QtySettlement = tsi.qty_settlement,
                              IsDelete = tsi.is_delete,
                              CreatedBy = tsi.created_by,
                              CreatedDate = tsi.created_date,
                              UpdatedBy = tsi.updated_by,
                              UpdatedDate = tsi.updated_date,
                          }).FirstOrDefault();

            }
            return result;
        }

        //public static Responses Update(T_SouvenirViewModel entity)
        //{
        //    Responses result = new Responses();
        //    try
        //    {
        //        using (var db = new MarcomContext())
        //        {
        //            if (entity.Id != 0)
        //            {
        //                t_souvenir t = db.t_souvenir.Where(o => o.id == entity.Id).FirstOrDefault();
        //                if (t != null)
        //                {
        //                    t.id = entity.Id;
        //                    t.code = entity.Code;
        //                    t.type = entity.Type;
        //                    t.t_event_id = entity.TEventId;
        //                    t.request_by = entity.RequestBy;
        //                    t.request_date = entity.RequestDate;
        //                    t.request_due_date = entity.RequestDueDate;
        //                    t.approved_by = entity.ApprovedBy;
        //                    t.approved_date = entity.ApprovedDate;
        //                    t.received_by = entity.ReceivedBy;
        //                    t.received_date = entity.ReceivedDate;
        //                    t.settlement_by = entity.SettlementBy;
        //                    t.settlement_date = entity.SettlementDate;
        //                    t.settlement_approved_by = entity.SettlementApprovedBy;
        //                    t.settlement_approved_date = entity.SettlementApprovedDate;
        //                    t.status = entity.Status;
        //                    t.note = entity.Note;
        //                    t.reject_reason = entity.RejectReason;
        //                    t.is_delete = entity.IsDelete;
        //                    t.updated_by = entity.UpdatedBy;
        //                    t.updated_date = entity.UpdatedDate;
        //                    db.SaveChanges();
        //                }
        //            }
        //            else
        //            {
        //                t_souvenir t = new t_souvenir();
        //                t.id = entity.Id;
        //                t.code = entity.Code;
        //                t.type = entity.Type;
        //                t.t_event_id = entity.TEventId;
        //                t.request_by = entity.RequestBy;
        //                t.request_date = entity.RequestDate;
        //                t.request_due_date = entity.RequestDueDate;
        //                t.approved_by = entity.ApprovedBy;
        //                t.approved_date = entity.ApprovedDate;
        //                t.received_by = entity.ReceivedBy;
        //                t.received_date = entity.ReceivedDate;
        //                t.settlement_by = entity.SettlementBy;
        //                t.settlement_date = entity.SettlementDate;
        //                t.settlement_approved_by = entity.SettlementApprovedBy;
        //                t.settlement_approved_date = entity.SettlementApprovedDate;
        //                t.status = entity.Status;
        //                t.note = entity.Note;
        //                t.reject_reason = entity.RejectReason;
        //                t.is_delete = entity.IsDelete;
        //                t.created_by = "Csk";
        //                t.created_date = DateTime.Now;

        //                foreach (var item in entity.DetailsSouvItem)
        //                {
        //                    t_souvenir_item Sitem = new t_souvenir_item();
        //                    Sitem.t_souvenir_id = t.id;
        //                    Sitem.m_souvenir_id = item.MSouvenirId;
        //                    Sitem.note = item.Note;
        //                    Sitem.qty = item.Qty;
        //                    Sitem.is_delete = item.IsDelete;
        //                    db.t_souvenir_item.Add(Sitem);
        //                }

        //                db.t_souvenir.Add(t);
        //                db.SaveChanges();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = ex.Message;
        //        result.Success = false;
        //    }
        //    return result;
        //}

        //public static Responses Delete(int Id)
        //{
        //    Responses result = new Responses();
        //    try
        //    {
        //        using (var db = new MarcomContext())
        //        {
        //            t_souvenir_item_item t_souvenir_item_item = db.t_souvenir_item_item.Where(o => o.id == Id).FirstOrDefault();

        //            if (t_souvenir_item_item != null)
        //            {
        //                db.t_souvenir_item_item.Remove(t_souvenir_item_item);
        //                db.SaveChanges();
        //            }
        //        }
        //    }

        //        catch (Exception ex)
        //        {
        //            result.Message = ex.Message;
        //            result.Success = false;
        //        }

        //        return result;

        //    }

        public static string GetNewCode()
        {
            int newIncrement = 1;
            string newCode = string.Format("TRSV", DateTime.Now.Day.ToString("D2"), DateTime.Now.Month.ToString("D2"), DateTime.Now.ToString("yy"));
            using (var db = new MarcomContext())
            {
                var result = (from e in db.m_employee
                              where e.employee_number.Contains(newCode)
                              select new { code = e.employee_number })
                              .OrderByDescending(o => o.code)
                              .FirstOrDefault();
                if (result != null)
                {
                    string[] oldCode = result.code.Split('.');
                    newIncrement = int.Parse(oldCode[3]) + 1;
                }

            }
            newCode += newIncrement.ToString("D5");
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


        ////public class MUResponse : Responses
        ////{
        ////    public string Reference { get; set; }
        ////}
    }
}
