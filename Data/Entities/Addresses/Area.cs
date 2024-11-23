using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Addresses
{
    public class Area :Distinct
    {
        
        public City City { get; set; }
        [ForeignKey("City")]
        public string CityId { get; set; }
    }

}
