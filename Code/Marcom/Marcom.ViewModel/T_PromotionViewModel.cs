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

        [Display(Name = "Event Code")]
        public string TEventCode { get; set; }

        [Display(Name = "Title Header")]
        public string TitleHeader { get; set; }

        public int? TDesignId { get; set; }

        [Display(Name = "Request By")]
        public string RequestName
        {
            get
            {
                return RFirstName + (string.IsNullOrEmpty(RLastName) ? "" : " " + RLastName);
            }
        }

        public string RFirstName { get; set; }

        public string RLastName { get; set; }

        public int? RequestBy { get; set; }

        [Display(Name = "Request Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? RequestDate { get; set; }

        public int? ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }
      
        public int? AssignTo { get; set; }

        [Display(Name = "Assign To")]
        public string AssignName
        {
            get
            {
                return AFirstName + (string.IsNullOrEmpty(ALastName) ? "" : " " + ALastName);
            }
        }

        public string AFirstName { get; set; }

        public string ALastName { get; set; }

        public DateTime? CloseDate { get; set; }

        public string Note { get; set; }

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
                else if(Status == 2)
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

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        
    }
}
