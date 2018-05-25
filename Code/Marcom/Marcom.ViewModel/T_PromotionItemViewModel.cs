using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class T_PromotionItemViewModel
    {
        public int Id { get; set; }
        public int TPromotionId { get; set; }
        public int? TDesignItemId { get; set; }
        public int MProductId { get; set; }
        public string Title { get; set; }
        public int RequestPic { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? RequestDueDate { get; set; }
        public decimal? Qty { get; set; }
        public int ToDo { get; set; }
        public string Note { get; set; }
        public bool? isDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
