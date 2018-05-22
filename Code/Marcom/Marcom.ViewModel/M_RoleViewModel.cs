using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class M_RoleViewModel
    {
        public M_RoleViewModel()
        {
            IsDelete = false;
        }
        public int Id { get; set; }

        [Display(Name ="Role Code"), Required]
        public string Code { get; set; }

        [Display(Name = "Role Name"), Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDelete { get; set; }

        [Display(Name = "Created By"), Required]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}"), Required]
        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
