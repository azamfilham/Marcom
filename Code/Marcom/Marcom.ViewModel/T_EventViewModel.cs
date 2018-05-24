using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class T_EventViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string EventName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Place { get; set; }
        public decimal? Budget { get; set; }
        public int RequestBy { get; set; }
        public DateTime RequestDate { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? AssignTo { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string Note { get; set; }
        public int? Status { get; set; }
        public string RejectReason { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
