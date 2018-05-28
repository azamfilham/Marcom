using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class T_SouvenirRepo
    {
        public static List<T_SouvenirViewModel> Get()
        {
            List<T_SouvenirViewModel> result = new List<T_SouvenirViewModel>();

            using (var db = new MarcomContext())
            {
                result = (from t in db.t_souvenir
                          join e in db.m_employee on
                          t.received_by equals e.id
                          select new T_SouvenirViewModel
                          {
                              Id = t.id,//
                              Code = t.code,//
                              Type = t.type,//
                              TEventId = t.t_event_id,//
                              RequestBy = t.request_by,
                              RequestDate = t.request_date,
                              RequestDueDate = t.request_due_date,
                              ApprovedBy = t.approved_by,
                              ApprovedDate = t.approved_date,

                              ReceivedBy = t.received_by,//
                              FirstName = e.first_name,
                              LastName = e.last_name,

                              ReceivedDate = t.received_date,//
                              SettlementBy = t.settlement_by,
                              SettlementDate = t.settlement_date,
                              SettlementApprovedBy = t.settlement_approved_by,
                              SettlementApprovedDate = t.settlement_approved_date,
                              Status = t.status,
                              Note = t.note,
                              RejectReason = t.reject_reason,
                              IsDelete = t.is_delete,
                              CreatedBy = t.created_by,
                              CreatedDate = t.created_date,
                              UpdatedBy = t.updated_by,
                              UpdatedDate = t.updated_date

                          }).ToList();
            }
            return result;
        }

        public static T_SouvenirViewModel GetById(int id)
        {
            T_SouvenirViewModel result = new T_SouvenirViewModel();

            using (var db = new MarcomContext())
            {
                result = (from t in db.t_souvenir
                          join e in db.m_employee on
                          t.received_by equals e.id
                          join tsi in db.t_souvenir_item on
                          t.id equals tsi.t_souvenir_id
                          where t.id == id
                          select new T_SouvenirViewModel
                          {
                              Id = t.id,//
                              Code = t.code,//
                              Type = t.type,//
                              TEventId = t.t_event_id,//
                              RequestBy = t.request_by,
                              RequestDate = t.request_date,
                              RequestDueDate = t.request_due_date,
                              ApprovedBy = t.approved_by,
                              ApprovedDate = t.approved_date,

                              ReceivedBy = t.received_by,//
                              FirstName = e.first_name,
                              LastName = e.last_name,

                              ReceivedDate = t.received_date,//
                              SettlementBy = t.settlement_by,
                              SettlementDate = t.settlement_date,
                              SettlementApprovedBy = t.settlement_approved_by,
                              SettlementApprovedDate = t.settlement_approved_date,
                              Status = t.status,
                              Note = t.note,
                              RejectReason = t.reject_reason,
                              IsDelete = t.is_delete,
                              CreatedBy = t.created_by,
                              CreatedDate = t.created_date,
                              UpdatedBy = t.updated_by,
                              UpdatedDate = t.updated_date,

                              QtyItem = tsi.qty,
                              MSouvNir = tsi.m_souvenir_id,
                              NoteItem = tsi.note
                              
                          }).FirstOrDefault();
            }

            return result;
        }


        public static Responses Update(T_SouvenirViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        t_souvenir t = db.t_souvenir.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (t != null)
                        {
                            t.id = entity.Id;
                            t.code = entity.Code;
                            t.type = entity.Type;
                            t.t_event_id = entity.TEventId;
                            t.request_by = entity.RequestBy;
                            t.request_date = entity.RequestDate;
                            t.request_due_date = entity.RequestDueDate;
                            t.approved_by = entity.ApprovedBy;
                            t.approved_date = entity.ApprovedDate;
                            t.received_by = entity.ReceivedBy;
                            t.received_date = entity.ReceivedDate;
                            t.settlement_by = entity.SettlementBy;
                            t.settlement_date = entity.SettlementDate;
                            t.settlement_approved_by = entity.SettlementApprovedBy;
                            t.settlement_approved_date = entity.SettlementApprovedDate;
                            t.status = entity.Status;
                            t.note = entity.Note;
                            t.reject_reason = entity.RejectReason;
                            t.is_delete = entity.IsDelete;
                            t.updated_by = entity.UpdatedBy;
                            t.updated_date = entity.UpdatedDate;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        t_souvenir t = new t_souvenir();
                        t.id = entity.Id;
                        t.code = entity.Code;
                        t.type = entity.Type;
                        t.t_event_id = entity.TEventId;
                        t.request_by = entity.RequestBy;
                        t.request_date = entity.RequestDate;
                        t.request_due_date = entity.RequestDueDate;
                        t.approved_by = entity.ApprovedBy;
                        t.approved_date = entity.ApprovedDate;
                        t.received_by = entity.ReceivedBy;
                        t.received_date = entity.ReceivedDate;
                        t.settlement_by = entity.SettlementBy;
                        t.settlement_date = entity.SettlementDate;
                        t.settlement_approved_by = entity.SettlementApprovedBy;
                        t.settlement_approved_date = entity.SettlementApprovedDate;
                        t.status = entity.Status;
                        t.note = entity.Note;
                        t.reject_reason = entity.RejectReason;
                        t.is_delete = entity.IsDelete;
                        t.created_by = "Csk";
                        t.created_date = DateTime.Now;

                        foreach (var item in entity.DetailsSouvItem)
                        {
                            t_souvenir_item Sitem = new t_souvenir_item();
                            Sitem.t_souvenir_id = t.id;
                            Sitem.m_souvenir_id = item.MSouvenirId;
                            Sitem.note = item.Note;
                            Sitem.qty = item.Qty;
                            Sitem.is_delete = item.IsDelete;
                            db.t_souvenir_item.Add(Sitem);
                        }

                        db.t_souvenir.Add(t);
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
            string newCode = string.Format("TRSV");
            using (var db = new MarcomContext())
            {
                var result = (from r in db.t_souvenir
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
