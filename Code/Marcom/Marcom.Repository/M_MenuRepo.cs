using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class M_MenuRepo
    {
        public static List<M_MenuViewModel> Get()
        {
            List<M_MenuViewModel> result = new List<M_MenuViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from m in db.m_menu
                          where m.is_delete == false
                          select new M_MenuViewModel
                          {
                              Id = m.id,
                              Code = m.code,
                              Name = m.name,
                              ParentId = m.parent_id,
                              CreatedBy = m.created_by,
                              CreatedDate = m.created_date
                          }).ToList();
            }
            return result;
        }

        public static M_MenuViewModel GetById(int id)
        {
            M_MenuViewModel result = new M_MenuViewModel();
            using (var db = new MarcomContext())
            {
                result = (from m in db.m_menu
                          where m.id == id 
                          select new M_MenuViewModel
                          {
                              Id = m.id,
                              Code = m.code,
                              Name = m.name,
                              Controller = m.controller,
                              CreatedBy = m.created_by,
                              CreatedDate = m.created_date
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(M_MenuViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        m_menu menu = db.m_menu.Where(m => m.id == entity.Id && m.id != entity.ParentId).FirstOrDefault();
                        if (menu != null)
                        {
                            menu.code = entity.Code;
                            menu.name = entity.Name;
                            menu.controller = entity.Controller;
                            menu.parent_id = entity.ParentId;
                            menu.is_delete = entity.IsDelete;
                            menu.updated_by = "Soleh";
                            menu.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        m_menu menu = new m_menu();
                        menu.code = GetNewCode();
                        menu.name = entity.Name;
                        menu.controller = entity.Controller;
                        menu.parent_id = entity.ParentId;
                        menu.is_delete = false;
                        menu.created_by = "Soleh";
                        menu.created_date = DateTime.Now;
                        db.m_menu.Add(menu);
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
                    m_menu menu = db.m_menu.Where(m => m.id == id).FirstOrDefault();
                    if (menu != null)
                    {

                        menu.is_delete = true;

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

        // buat generet
        public static string GetNewCode()
        {

            int newIncrement = 1;
            string newCode = string.Format("ME");
            using (var db = new MarcomContext())
            {
                var result = (from m in db.m_menu
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

        //parent id
        public static List<M_MenuViewModel> GetByParentId(int PId)
        {
            List<M_MenuViewModel> result = new List<M_MenuViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from m in db.m_menu
                         where m.id != PId && m.is_delete == false
                          select new M_MenuViewModel
                          {
                              Id = m.id,
                              Code = m.code,
                              Name = m.name,
                              ParentId = m.parent_id
                          }).ToList();
            }
            return result;
        }

        public Boolean checkName(string name)
        {
            M_MenuViewModel result = new M_MenuViewModel();
            using (var db = new MarcomContext())
            {
                result = (from m in db.m_menu
                          where m.name == name
                          select new M_MenuViewModel
                          {
                              Id = m.id,
                             
                              Name = m.name
                              
                          }).FirstOrDefault();
            }
            
            if (result == null)
            {
                return true;
            }


            return false;
        }
    }
}

