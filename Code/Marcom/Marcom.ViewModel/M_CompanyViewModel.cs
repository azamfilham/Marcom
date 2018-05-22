﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class M_CompanyViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Company Code")]
        public string Code { get; set; }
        [Display(Name = "Company Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsDelete { get; set; }
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
