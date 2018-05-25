using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class T_DesignViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Transaction Code")]
        public string Code { get; set; }

        [Display(Name = "Event Code")]
        public int TEventId { get; set; }

        [Display(Name = "Event Code")]
        public int TEventName { get; set; }

        [Display(Name = "Design Title")]
        public string TitleHeader { get; set; }

        [Display(Name = "Request By")]
        public int RequestBy { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Employee Name")]
        public string FullName
        {
            get
            {
                return FirstName + (string.IsNullOrEmpty(LastName) ? "" : " " + LastName);
            }
        }

        [Display(Name = "Request Date")]
        public System.DateTime RequestDate { get; set; }

        public string RDate
        {
            get
            {
                return RequestDate.ToString("dd-MM-yyyy");
            }
        }
        public int? ApprovedBy { get; set; }
        public System.DateTime? ApprovedDate { get; set; }
        public int? AssignTo { get; set; }
        public System.DateTime? ClosedDate { get; set; }
        public string Note { get; set; }
        public int? Status { get; set; }
        public string RejectReason { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CDate
        {
            get
            {
                return RequestDate.ToString("dd-MM-yyyy");
            }
        }
        public string UpdatedBy { get; set; }
        public System.DateTime? UpdatedDate { get; set; }
    }
}
