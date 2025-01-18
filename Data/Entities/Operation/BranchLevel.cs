using Data.Entities.Addresses;
using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Operation
{
    public class BranchLevel : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public Area Area { get; set; }
        [MaxLength(50)]
        [ForeignKey("Area")]
        public string AreaId { get; set; }
        [MaxLength(50)]
        public string ContactPhone { get; set; }
        public DateTime OpenTime { get; set; }
        public LevelTypeEnum LevelType { get; set; }
        public StatusEnum Status { get; set; }
        public BranchLevel AffiliatedAgency { get; set; }
        [ForeignKey("AffiliatedAgency")]
        public int AffiliatedAgencyId { get; set; }
        public BranchLevel AffiliatedHQ { get; set; }
        [ForeignKey("AffiliatedHQ")]
        public int AffiliatedHQId { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
        public string? PrincipalName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Wallet { get; set; } = 0;
        [MaxLength(100)]
        public string? Center { get; set; }

    }

}
