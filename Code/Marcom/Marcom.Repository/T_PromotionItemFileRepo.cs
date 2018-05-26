using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class T_PromotionItemFileRepo
    {
        public static List<T_PromotionItemFileViewModel> Get()
        {
            List<T_PromotionItemFileViewModel> result = new List<T_PromotionItemFileViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from pif in db.t_promotion_item_file
                          where pif.is_delete == false
                          select new T_PromotionItemFileViewModel
                          {
                             Id = pif.id,
                             TPromotionId = pif.t_promotion_id,
                             FileName = pif.filename,
                             Size = pif.size,
                             Extention = pif.extention,
                             StartDate = pif.start_date,
                             EndDate = pif.end_date,
                             RequestDueDate = pif.request_due_date,
                             Qty = pif.qty,
                             Todo = pif.todo,
                             Note = pif.note
                          }).ToList();
            }
            return result;
        }

        public static T_PromotionItemFileViewModel GetById(int id)
        {
            T_PromotionItemFileViewModel result = new T_PromotionItemFileViewModel();
            using (var db = new MarcomContext())
            {
                result = (from pif in db.t_promotion_item_file
                           where pif.id == id
                           select new T_PromotionItemFileViewModel
                          {
                              Id = pif.id,
                              TPromotionId = pif.t_promotion_id,
                              FileName = pif.filename,
                              Size = pif.size,
                              Extention = pif.extention,
                              StartDate = pif.start_date,
                              EndDate = pif.end_date,
                              RequestDueDate = pif.request_due_date,
                              Qty = pif.qty,
                              Todo = pif.todo,
                              Note = pif.note
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(T_PromotionItemFileViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        t_promotion_item_file tpifile = db.t_promotion_item_file.Where(tpif => tpif.id == entity.Id ).FirstOrDefault();
                        if (tpifile != null)
                        {
                            tpifile.t_promotion_id = entity.TPromotionId;
                            tpifile.filename = entity.FileName;
                            tpifile.size = entity.Size;
                            tpifile.extention = entity.Extention;
                            tpifile.start_date = entity.StartDate;
                            tpifile.end_date = entity.EndDate;
                            tpifile.request_due_date = entity.RequestDueDate;
                            tpifile.qty = entity.Qty;
                            tpifile.todo = entity.Todo;
                            tpifile.note = entity.Note;   
                            tpifile.is_delete = entity.IsDelete;
                            tpifile.updated_by = "Soleh";
                            tpifile.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        t_promotion_item_file tpifile = new t_promotion_item_file();
                        tpifile.t_promotion_id = entity.TPromotionId;
                        tpifile.filename = entity.FileName;
                        tpifile.size = entity.Size;
                        tpifile.extention = entity.Extention;
                        tpifile.start_date = entity.StartDate;
                        tpifile.end_date = entity.EndDate;
                        tpifile.request_due_date = entity.RequestDueDate;
                        tpifile.qty = entity.Qty;
                        tpifile.todo = entity.Todo;
                        tpifile.note = entity.Note;
                        tpifile.is_delete = false;
                        tpifile.created_by = "Soleh";
                        tpifile.created_date = DateTime.Now;

                        db.t_promotion_item_file.Add(tpifile);
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
                    t_promotion_item_file tpifile = db.t_promotion_item_file.Where(m => m.id == id).FirstOrDefault();
                    if (tpifile != null)
                    {

                        tpifile.is_delete = true;

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
