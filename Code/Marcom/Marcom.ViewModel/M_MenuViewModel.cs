using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Marcom.ViewModel
{
    public class M_MenuViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Code"), Required, MaxLength(50)]
        public string Code { get; set; }

        [Display(Name = "Menu Name"), Required, MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Controller Name"), Required, MaxLength(150)]
        public string Controller { get; set; }

        public bool IsDelete { get; set; }

        [Display(Name = "Parrent")]
        public int? ParentId { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        
    }
}
