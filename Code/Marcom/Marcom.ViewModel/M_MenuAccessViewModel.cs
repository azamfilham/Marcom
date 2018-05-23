using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class M_MenuAccessViewModel
    {
        //public M_MenuAccessViewModel()
        //{
        //    IsDelete = false;
        //}

        public int Id { get; set; }

        [Display(Name ="Role")]
        public int MRoleId { get; set; }

        [Display(Name = "Menu Access")]
        public int MMenuId { get; set; }

        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
