using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class T_PromotionViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Transaction Code")]
        public string Code { get; set; }
        public string FlagDesign { get; set; }
        public int TEventId { get; set; }
        public int? TDesignId { get; set; }
        public int? RequestBy { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? AssignTo { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Note { get; set; }
        public int? Status { get; set; }
        public string RejectReason { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
