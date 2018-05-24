using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class M_ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Product Code")]
        public string Code { get; set; }

        [Display(Name = "Product Name"), Required(ErrorMessage = "Please enter Unit Name.")]
        public string Name { get; set; }

        [Display(Name = "Description"), Required(ErrorMessage = "Please enter Description.")]
        public string Description { get; set; }
        public bool IsDelete { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Update Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? UpdatedDate { get; set; }
    }
}
