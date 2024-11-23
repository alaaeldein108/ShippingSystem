using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Addresses
{
    public class City : Distinct
    {
        public Province Province { get; set; }
        [ForeignKey("Province")]
        public string ProvinceId { get; set; }
    }

}
