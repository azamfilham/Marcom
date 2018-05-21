using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class M_EmployeeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Employee ID Number"), Required]
        public string EmployeeNumber { get; set; }

        [Display(Name = "First Name"), Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Company Name")]
        public int? MCompanyId { get; set; }

        [Display(Name = "Company Name")]
        public string MCompanyName { get; set; }

        public string Email { get; set; }

        public bool IsDelete { get; set; }

        public string CreatedBy { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public System.DateTime? UpdatedDate { get; set; }
    }
}