using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom.ViewModel
{
    public class M_SouvenirViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Souvenir Code")]
        public string Code { get; set; }
        [Display(Name ="Souvenir Name"), Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name ="Unit Name")]
        public int mUnitId { get; set; }
        public string unitName { get; set; }
        public bool isDelete { get; set; }

        [Display(Name = "Created By")]
        public string Created_by { get; set; }

        [Display(Name ="Created Date")]
        public DateTime Created_date { get; set; }

        public string Updated_by { get; set; }

        public DateTime? Updated_date { get; set; }
    }
}
