using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class T_DesignItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Design ID"), Required]
        public int TDesignId { get; set; }
        [Display(Name = "Product ID"), Required]
        public int MProductId { get; set; }
        [Display(Name = "Title Item"), Required]
        public string TitleItem { get; set; }
        public int RequestPic { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? RequestDueDate { get; set; }
        public string Note { get; set; }
        public bool? IsDelete { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Update By")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Update Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? UpdatedDate { get; set; }
    }
}
