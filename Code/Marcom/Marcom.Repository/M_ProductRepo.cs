using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class M_ProductRepo
    {
        public static List<M_ProductViewModel> Get()
        {
            List<M_ProductViewModel> result = new List<M_ProductViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from u in db.m_product
                          where u.is_delete == false
                          select new M_ProductViewModel
                          {
                              Id = u.id,
                              Code = u.code,
                              Name = u.name,
                              Description = u.description,
                              CreatedDate = u.created_date,
                              CreatedBy = u.created_by,
                          }).ToList();
            }
            return result;
        }

        public static M_ProductViewModel GetById(int Id)
        {
            M_ProductViewModel result = new M_ProductViewModel();
            using (var db = new MarcomContext())
            {
                result = (from u in db.m_product
                          where u.id == Id
                          select new M_ProductViewModel
                          {
                              Id = u.id,
                              Code = u.code,
                              Name = u.name,
                              Description = u.description,
                              CreatedBy = u.created_by,
                              CreatedDate = u.created_date,
                          }).FirstOrDefault();

            }
            return result;
        }

        public static Responses update(M_ProductViewModel entity)
        {
            Responses result = new Responses();

            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        m_product m_product = db.m_product.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (m_product != null)
                        {
                            m_product.code = entity.Code;
                            m_product.name = entity.Name;
                            m_product.description = entity.Description;
                            m_product.is_delete = entity.IsDelete;
                            m_product.updated_by = "David";
                            m_product.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }

                    }

                    else
                    {
                        m_product m_product = new m_product();
                        m_product.code = entity.Code;
                        m_product.name = entity.Name;
                        m_product.description = entity.Description;
                        m_product.is_delete = entity.IsDelete;
                        m_product.created_by = entity.CreatedBy;
                        m_product.created_date = DateTime.Now;           
                        db.m_product.Add(m_product);
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

        public static Responses Delete(int Id)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    m_product m_product = db.m_product.Where(o => o.id == Id).FirstOrDefault();

                    if (m_product != null)
                    {
                        m_product.is_delete = true;
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
            string newCode = string.Format("PR");
            using (var db = new MarcomContext())
            {
                var result = (from r in db.m_product
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

    //public class MUResponse : Responses
    //{
    //    public string Reference { get; set; }
    //}
}

