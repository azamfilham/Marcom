using Marcom.DataModel;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.Repository
{
    public class M_SouvenirRepo
    {
        public static List<M_SouvenirViewModel> Get()
        {
            List<M_SouvenirViewModel> result = new List<M_SouvenirViewModel>();
            using (var db = new MarcomContext())
            {
                result = (from s in db.m_souvenir
                          join u in db.m_unit on
                          s.m_unit_id equals u.id
                          where s.is_delete == false
                          select new M_SouvenirViewModel
                          {
                              Id = s.id,
                              Code = s.code,
                              Name = s.name,
                              Description = s.description,
                              mUnitId = s.m_unit_id,
                              unitName = u.name,
                              Created_by = s.created_by,
                              Created_date = s.created_date,
                              isDelete = s.is_delete
                          }).ToList();
            }
            return result;
        }

        public static M_SouvenirViewModel GetById(int id)
        {
            M_SouvenirViewModel result = new M_SouvenirViewModel();
            using (var db = new MarcomContext())
            {
                result = (from s in db.m_souvenir
                          join u in db.m_unit on
                          s.m_unit_id equals u.id
                          where s.id == id
                          select new M_SouvenirViewModel
                          {
                              Id = s.id,
                              Code = s.code,
                              Name = s.name,
                              Description = s.description,
                              mUnitId = s.m_unit_id,
                              unitName = u.name,
                              Created_by = s.created_by,
                              Created_date = s.created_date,
                              isDelete = s.is_delete
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(M_SouvenirViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new MarcomContext())
                {
                    if (entity.Id != 0)
                    {
                        m_souvenir souvenir = db.m_souvenir.Where(o => o.id == entity.Id).FirstOrDefault();
                        if (souvenir != null)
                        {
                            souvenir.id = entity.Id;
                            souvenir.code = entity.Code;
                            souvenir.name = entity.Name;
                            souvenir.description = entity.Description;
                            souvenir.m_unit_id = entity.mUnitId;
                            souvenir.is_delete = entity.isDelete;
                            souvenir.updated_by = "Asyam";
                            souvenir.updated_date = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        m_souvenir souvenir = new m_souvenir();
                        souvenir.id = entity.Id;
                        souvenir.code = GetNewCode();
                        souvenir.name = entity.Name;
                        souvenir.description = entity.Description;
                        souvenir.m_unit_id = entity.mUnitId;
                        souvenir.is_delete = false;
                        souvenir.created_by = "Asyam";
                        souvenir.created_date = DateTime.Now;
                        db.m_souvenir.Add(souvenir);
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
                    m_souvenir souvenir = db.m_souvenir.Where(o => o.id == id).FirstOrDefault();
                    if (souvenir != null)
                    {
                        souvenir.is_delete = true;
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
