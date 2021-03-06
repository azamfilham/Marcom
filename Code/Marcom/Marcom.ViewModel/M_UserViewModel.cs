﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Marcom.ViewModel
{
    public class M_UserViewModel
    {        
        public int Id { get; set; }

        [Display(Name = "Username"), Required]
        public string Username { get; set; }

        [Display(Name = "Password"), Required]
        public string Password { get; set; }

        [Display(Name = "Re-Type Password")]
        [Compare("Password", ErrorMessage = "Password Harus Sama!!!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Role Name")]
        public int MRoleId { get; set; }

        [Display(Name = "Role")]
        public string RoleName { get; set; }
                
        [Display(Name = "Employee Name")]
        public int MEmployeeId { get; set; }

        [Display(Name = "Employee")]
        public string FirstName { get; set; }

        [Display(Name = "Employee")]
        public string LastName { get; set; }

        [Display(Name = "Employee Name")]
        public string FullName
        {
            get
            {
                return FirstName + (string.IsNullOrEmpty(LastName) ? "" : " " + LastName);
            }
        }

        public int MCompanyId { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        public bool IsDelete { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Upadated Date")]
        public DateTime? UpdatedDate { get; set; }
    }
}
