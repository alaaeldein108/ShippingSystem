using Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Enums;
using Data.Entities.Addresses;

namespace Data.Entities.Operation
{
    public class BranchLevel:BaseEntity
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public Area Area { get; set; }
        [ForeignKey("Area")]
        public string AreaId { get; set; }
        public string ContactPhone { get; set; }
        public DateTime OpenTime { get; set; }
        public LevelTypeEnum LevelType { get; set; }
        public StatusEnum Status { get; set; }
        public string? Notes { get; set; }
        public string? PrincipalId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Wallet { get; set; } = 0;
    }

}
