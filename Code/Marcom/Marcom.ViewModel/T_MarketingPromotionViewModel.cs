using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class T_MarketingPromotionViewModel
    {
        public T_PromotionViewModel Promotion { get; set; }
        public T_PromotionItemViewModel PromotionItem { get; set; }
        public T_PromotionItemFileViewModel PromotionItemFile { get; set; }
        public T_DesignViewModel Design { get; set; }
        public T_DesignItemViewModel DesignItem { get; set; }
    }
}
