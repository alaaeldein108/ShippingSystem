using Data.Entities.Enums;
using Data.Entities.Operation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Finance
{
    public class Zone : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public ZoneTypeEnum ZoneType { get; set; }
        public BranchLevel AffailiatedBranch { get; set; }
        [ForeignKey("AffailiatedBranch")]
        public int AffailiatedBranchId { get; set; }
        public StatusEnum Status { get; set; }
        public QuotationTypeEnum QuotationType { get; set; }
        public ICollection<ZoneCity> Cities { get; set; } = new List<ZoneCity>();
        public ICollection<QuotationZone> QuotationZones { get; set; } = new List<QuotationZone>();

    }

}
