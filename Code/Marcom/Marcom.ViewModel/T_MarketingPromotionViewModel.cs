using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class T_MarketingPromotionViewModel
    {
        public T_PromotionViewModel PromotionDetail { get; set; }
        public T_PromotionItemViewModel PromotionItemDetail { get; set; }
        public T_PromotionItemFileViewModel PromotionItemFileDetail { get; set; }
        public T_DesignViewModel DesignDetail { get; set; }
        public T_DesignItemViewModel DesignItemDetail { get; set; }
    }
}
