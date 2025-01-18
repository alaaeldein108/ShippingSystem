using Data.Entities.Addresses;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Finance
{
    public class ZoneCity
    {
        public Zone Zone { get; set; }
        [ForeignKey("Zone")]
        public int ZoneId { get; set; }
        public City City { get; set; }
        [ForeignKey("City")]
        public string CityId { get; set; }

    }
}
