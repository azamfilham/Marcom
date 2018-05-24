using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PERLU BANYAK EDIT
namespace Marcom.ViewModel
{
    public class T_SouvinerItemViewModel
    {
        public int Id { get; set; }
        public int TSouvenirId { get; set; }

        [Display(Name = "Transaction Code")]
        public string TransactionCode  { get; set; }

        [Display(Name = "Request By")]
        public int RequestBy { get; set; }

        [Display(Name = "Request Date")]
        public DateTime? RequestDate { get; set; }

        [Display(Name = "Even Code")]
        public string EvenCode { get; set; }


        [Display(Name = "Souvenir Name")]
        public string SouvenirName { get; set; }

        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public int MSouvenirId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? QtySettlement { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Note")]
        public string Note2 { get; set; }

        public bool IsDelete { get; set; } 

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
