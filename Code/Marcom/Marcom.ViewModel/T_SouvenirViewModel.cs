using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class T_SouvenirViewModel
    {
        public int Id { get; set; }
        
        [Display(Name ="Transaction Code")]
        public string Code { get; set; }

        public string Type { get; set; }
        public int TEventId { get; set; }
        public int RequestBy { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? RequestDueDate { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

        [Display(Name = "Received By")]
        public int? ReceivedBy { get; set; }
        public string EmployeeName
        {
            get
            {
                return FirstName + (string.IsNullOrEmpty(LastName) ? "" : " " + LastName);
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Received Date")]
        public DateTime? ReceivedDate { get; set; }

        public int? SettlementBy { get; set; }
        public DateTime? SettlementDate { get; set; }
        public int? SettlementApprovedBy { get; set; }
        public DateTime? SettlementApprovedDate { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string RejectReason { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
