using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class T_PromotionItemRepo
    {
        public static List<T_PromotionItemViewModel> Get()
        {
            List<T_PromotionItemViewModel> result = new List<T_PromotionItemViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from p in db.t_promotion_item

                          select new T_PromotionItemViewModel
                          {
                              Id = p.id,
                              TPromotionId = p.t_promotion_id,
                              TDesignItemId = p.t_design_item_id,
                              MProductId = p.m_product_id,
                              Title = p.title,
                              RequestPic = p.request_pic,
                              StartDate = p.start_date,
                              EndDate = p.end_date,
                              RequestDueDate = p.request_due_date,
                              Qty = p.qty,
                              ToDo = p.todo,
                              Note = p.note,
                              isDelete = p.is_delete,
                              CreatedBy = p.created_by,
                              CreatedDate = p.created_date
                          }).ToList();
            }
            return result;
        }

        public static T_PromotionItemViewModel GetById(int id)
        {
            T_PromotionItemViewModel result = new T_PromotionItemViewModel();
            using (var db = new MarcomContext())
            {
                result = (from p in db.t_promotion_item
                          select new T_PromotionItemViewModel
                          {
                              Id = p.id,
                              TPromotionId = p.t_promotion_id,
                              TDesignItemId = p.t_design_item_id,
                              MProductId = p.m_product_id,
                              Title = p.title,
                              RequestPic = p.request_pic,
                              StartDate = p.start_date,
                              EndDate = p.end_date,
                              RequestDueDate = p.request_due_date,
                              Qty = p.qty,
                              ToDo = p.todo,
                              Note = p.note,
                              isDelete = p.is_delete,
                              CreatedBy = p.created_by,
                              CreatedDate = p.created_date
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(T_PromotionItemViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        t_promotion_item promotion = db.t_promotion_item.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (promotion != null)
                        {
                            promotion.id = entity.Id;
                            promotion.t_promotion_id = entity.TPromotionId;
                            promotion.t_design_item_id = entity.TDesignItemId;
                            promotion.m_product_id = entity.MProductId;
                            promotion.title = entity.Title;
                            promotion.request_pic = entity.RequestPic;
                            promotion.start_date = entity.StartDate;
                            promotion.end_date = entity.EndDate;
                            promotion.request_due_date = entity.RequestDueDate;
                            promotion.qty = entity.Qty;
                            promotion.todo = entity.ToDo;
                            promotion.note = entity.Note;
                            promotion.is_delete = entity.isDelete;
                            promotion.updated_by = "Asyam";
                            promotion.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        t_promotion_item promotion = new t_promotion_item();
                        promotion.id = entity.Id;
                        promotion.t_promotion_id = entity.TPromotionId;
                        promotion.t_design_item_id = entity.TDesignItemId;
                        promotion.m_product_id = entity.MProductId;
                        promotion.title = entity.Title;
                        promotion.request_pic = entity.RequestPic;
                        promotion.start_date = entity.StartDate;
                        promotion.end_date = entity.EndDate;
                        promotion.request_due_date = entity.RequestDueDate;
                        promotion.qty = entity.Qty;
                        promotion.todo = entity.ToDo;
                        promotion.note = entity.Note;
                        promotion.is_delete = entity.isDelete;
                        promotion.created_by = "Asyam";
                        promotion.created_date = DateTime.Now;
                        db.t_promotion_item.Add(promotion);
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
                    t_promotion_item promotion = db.t_promotion_item.Where(o => o.id == id).FirstOrDefault();
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
            string newCode = string.Format("SV");
            using (var db = new MarcomContext())
            {
                var result = (from m in db.m_souvenir
                              where m.code.Contains(newCode)
                              select new { code = m.code })
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
