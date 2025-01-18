using Data.Entities.Finance;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Addresses
{
    public class City : Distinct
    {
        public Province Province { get; set; }
        [MaxLength(50)]
        [ForeignKey("Province")]
        public string ProvinceId { get; set; }
        public ICollection<ZoneCity> Cities { get; set; } = new List<ZoneCity>();

    }

}
