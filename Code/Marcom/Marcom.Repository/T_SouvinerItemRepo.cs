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
                              TransactionCode = ts.code,
                              RequestBy = ts.request_by,
                              RequestDate = ts.request_date,
                              DueDate = ts.request_due_date,
                              CreatedBy = tsi.created_by,
                              CreatedDate = tsi.created_date,
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
                              Note = ts.note,
                              SouvenirName = ms.name,
                              Qty = tsi.qty,
                              Note2 = tsi.note,
                          }).FirstOrDefault();

            }
            return result;
        }

		public static List<T_SouvinerItemViewModel> GetBySouvId(int SouvId)
        {
            List<T_SouvinerItemViewModel> result = new List<T_SouvinerItemViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from souvItem in db.t_souvenir_item
                          join souv in db.t_souvenir
                          on souvItem.t_souvenir_id equals souv.id
                          join mSouv in db.m_souvenir
                          on souvItem.m_souvenir_id equals mSouv.id
                          where souvItem.t_souvenir_id == SouvId
                          select new T_SouvinerItemViewModel
                          {
                              Id = souvItem.id,
                              MSouvenirId = souvItem.m_souvenir_id,
                              Qty = souvItem.qty,
                              Note = souvItem.note,
                              SouvenirName = mSouv.name


                          }).ToList();
            }
            return result;
        }
		
        //public static Responses update(T_SouvinerItemViewModel entity)
        //{
        //    Responses result = new Responses();

        //    try
        //    {
        //        using (var db = new MarcomContext())
        //        {
        //            if (entity.Id != 0)
        //            {
        //                t_souvenir_item t_souvenir_item = db.t_souvenir_item.Where(o => o.id == entity.Id).FirstOrDefault();
        //                if (t_souvenir_item != null)
        //                {
        //                    t_souvenir_item.co = entity.Code;
        //                    t_souvenir_item.name = entity.Name;
        //                    t_souvenir_item.description = entity.Description;
        //                    t_souvenir_item.is_delete = entity.IsDelete;
        //                    t_souvenir_item.updated_by = "David";
        //                    t_souvenir_item.updated_date = DateTime.Now;
        //                    db.SaveChanges();
        //                }

        //            }

        //            else
        //            {
        //                t_souvenir_item t_souvenir_item = new t_souvenir_item();
        //                t_souvenir_item.code = GetNewCode();
        //                t_souvenir_item.name = entity.Name;
        //                t_souvenir_item.description = entity.Description;
        //                t_souvenir_item.is_delete = entity.IsDelete;
        //                t_souvenir_item.created_by = "David";
        //                t_souvenir_item.created_date = DateTime.Now;
        //                db.t_souvenir_item.Add(t_souvenir_item);
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
        //            t_souvenir_item t_souvenir_item = db.t_souvenir_item.Where(o => o.id == Id).FirstOrDefault();

        //            if (t_souvenir_item != null)
        //            {
        //                db.t_souvenir_item.Remove(t_souvenir_item);
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
        //    public static string GetNewCode()
        //    {
        //        int newIncrement = 1;
        //        string newCode = string.Format("UN");
        //        using (var db = new MarcomContext())
        //        {
        //            var result = (from r in db.t_souvenir_item
        //                          where r.code.Contains(newCode)
        //                          select new { code = r.code })
        //                          .OrderByDescending(o => o.code)
        //                          .FirstOrDefault();
        //            if (result != null)
        //            {
        //                string[] oldCode = SplitCode(result.code);
        //                newIncrement = int.Parse(oldCode[0]) + 1;
        //            }

        //        }
        //        newCode += newIncrement.ToString("D4");
        //        return newCode;
        //    }

        //    public static string[] SplitCode(string data)
        //    {
        //        string numbers = "";
        //        string alpha = "";
        //        foreach (char c in data)
        //        {
        //            if (Char.IsDigit(c))
        //            {
        //                numbers = numbers + c;
        //            }
        //            else if (Char.IsLetter(c))
        //            {
        //                alpha = alpha + c;
        //            }
        //        }
        //        return new string[] { numbers, alpha };
        //    }
        //}

        ////public class MUResponse : Responses
        ////{
        ////    public string Reference { get; set; }
        ////}
    }
}
