using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Marcom.ViewModel
{
    public class T_EventViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Transaction Code")]
        public string Code { get; set; }

        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Display(Name = "Event Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Event End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Event Place")]
        public string Place { get; set; }

        [Display(Name = "Budget (Rp.)")]
        public decimal? Budget { get; set; }

        [Display(Name = "Request By")]
        public int RequestBy { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Request By")]
        public string FullName
        {
            get
            {
                return FirstName + (string.IsNullOrEmpty(LastName) ? "" : " " + LastName);
            }
        }

        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }

        public int? ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public int? AssignTo { get; set; }

        public DateTime? ClosedDate { get; set; }

        public string Note { get; set; }

        [Display(Name = "Status")]
        public int? Status { get; set; }

        [Display(Name = "Status")]
        public string StatusName
        {
            get
            {
                if (Status == 1)
                {
                    return "Submitted";
                }
                else if (Status == 2)
                {
                    return "In Progress";
                }
                else if (Status == 3)
                {
                    return "Done";
                }
                else
                {
                    return "Rejected";
                }
            }

        }

        public string RejectReason { get; set; }

        public bool? IsDelete { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
