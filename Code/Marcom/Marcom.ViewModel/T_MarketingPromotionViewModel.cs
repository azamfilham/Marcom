﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class T_MarketingPromotionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Transaction Code")]
        public string Code { get; set; }

        public string FlagDesign { get; set; }
        //bagian event

        public int TEventId { get; set; }

        [Display(Name = "Event Code")]
        public string TEventCode { get; set; }

        [Display(Name = "Title Header")]
        public string TitleHeader { get; set; }

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

        [Display(Name = "Request By")]
        public int? RequestBy { get; set; }

        [Display(Name = "Request Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? RequestDate { get; set; }

        public string Note { get; set; }


        //Design
        public int? TDesignId { get; set; }

        [Display(Name = "Design Code")]
        public string TDesignCode { get; set; }

        public int TDesignRequestPIC { get; set; }

        [Display(Name = "Request Date")]
        public System.DateTime TDesignRequestDate { get; set; }

        [Display(Name = "Note")]
        public string TDesignNote { get; set; }

        [Display(Name = "Request By")]
        public int? TDesignRequestBy { get; set; }

        [Display(Name = "Request By")]
        public string DesignRequestName
        {
            get
            {
                return DFirstName + (string.IsNullOrEmpty(DLastName) ? "" : " " + DLastName);
            }
        }

        public string DFirstName { get; set; }

        public string DLastName { get; set; }

        [Display(Name = "Title Header")]
        public string TDesignTitleHeader { get; set; }


    }
}
