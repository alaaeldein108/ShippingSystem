using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Addresses
{
    public class Area : Distinct
    {

        public City City { get; set; }
        [MaxLength(50)]
        [ForeignKey("City")]
        public string CityId { get; set; }

    }

}
