using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class T_DesignItemRepo
    {
        public static List<T_DesignItemViewModel> Get()
        {
            List<T_DesignItemViewModel> result = new List<T_DesignItemViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from di in db.t_design_item
                          join d in db.t_design on
                          di.t_design_id equals d.id
                          join p in db.m_product on
                          di.m_product_id equals p.id
                          select new T_DesignItemViewModel
                          {
                              Id = di.id,
                              TDesignId = d.id,
                              MProductId = di.m_product_id,
                              TitleItem = di.title_item,
                              RequestPic = di.request_pic,
                              StartDate = di.start_date,
                              EndDate = di.end_date,
                              RequestDueDate = di.request_due_date,
                              Note = di.note,
                              IsDelete = di.is_delete,
                              CreatedBy = di.created_by,
                              CreatedDate = di.created_date,
                              UpdatedBy = di.updated_by,
                              UpdatedDate = di.updated_date
                          }).ToList();
            }
            return result;
        }
        public static T_DesignItemViewModel GetById(int id)
        {
            T_DesignItemViewModel result = new T_DesignItemViewModel();
            using (var db = new MarcomContext())
            {
                result = (from di in db.t_design_item
                          join d in db.t_design on
                          di.t_design_id equals d.id
                          join p in db.m_product on
                          di.m_product_id equals p.id
                          select new T_DesignItemViewModel
                          {
                              Id = di.id,
                              TDesignId = d.id,
                              MProductId = di.m_product_id,
                              TitleItem = di.title_item,
                              RequestPic = di.request_pic,
                              StartDate = di.start_date,
                              EndDate = di.end_date,
                              RequestDueDate = di.request_due_date,
                              Note = di.note,
                              IsDelete = di.is_delete,
                              CreatedBy = di.created_by,
                              CreatedDate = di.created_date,
                              UpdatedBy = di.updated_by,
                              UpdatedDate = di.updated_date
                          }).FirstOrDefault();
            }
            return result;
        }
        public static Responses Update(T_DesignItemViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        t_design_item di = db.t_design_item.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (di != null)
                        {
                            di.t_design_id = entity.TDesignId;
                            di.m_product_id = entity.MProductId;
                            di.title_item = entity.TitleItem;
                            di.request_pic = entity.RequestPic;
                            di.start_date = entity.StartDate;
                            di.end_date = entity.EndDate;
                            di.request_due_date = entity.RequestDueDate;
                            di.note = entity.Note;
                            di.is_delete = entity.IsDelete;
                            di.updated_by = "Andra";
                            di.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        t_design_item di = new t_design_item();
                        di.t_design_id = entity.TDesignId;
                        di.m_product_id = entity.MProductId;
                        di.title_item = entity.TitleItem;
                        di.request_pic = entity.RequestPic;
                        di.start_date = entity.StartDate;
                        di.end_date = entity.EndDate;
                        di.request_due_date = entity.RequestDueDate;
                        di.note = entity.Note;
                        di.is_delete = entity.IsDelete;
                        di.created_by = "Andra";
                        di.created_date = DateTime.Now;
                        db.t_design_item.Add(di);
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
                    t_design_item di = db.t_design_item.Where(o => o.id == id).FirstOrDefault();
                    if (di != null)
                    {
                        di.is_delete = true;
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
