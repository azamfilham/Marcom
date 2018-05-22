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
        [Required]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int mUnitId { get; set; }
        public string unitName { get; set; }
        public bool isDelete { get; set; }
        public string Created_by { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Created_date { get; set; }

        public string Updated_by { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Updated_date { get; set; }
    }
}
