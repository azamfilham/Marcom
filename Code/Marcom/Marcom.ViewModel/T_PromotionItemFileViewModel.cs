using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class T_PromotionItemFileViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Promotion Id")]
        public int TPromotionId { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name = "Size")]
        public string Size { get; set; }

        [Display(Name = "Extention")]
        public string Extention { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Due Date")]
        public DateTime? RequestDueDate { get; set; }

        [Display(Name = "QTY")]
        public decimal? Qty { get; set; }

        
        public int Todo { get; set; }

        [Display(Name = "Todo")]
        public string TodoList
        {
            get
            {
                if (Todo == 1)
                {
                    return "Print / Cetak";
                }
                else if (Todo == 2)
                {
                    return "Posting Sosial Media";
                }
             
                else
                {
                    return "Unknown";
                }
            }
        }

        [Display(Name = "Note")]
        public string Note { get; set; }

        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
