using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Finance
{
    public class Formula
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinWeight { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxWeight { get; set; } = 0;
        public WeightingRoundModeEnum WeightingRoundMode { get; set; }
        [MaxLength(100)]
        public string FormulaEquation { get; set; }
        // Foreign keys to Quotation_Zone composite key
        public int ZoneId { get; set; }
        public int QuotationId { get; set; }

        [ForeignKey("ZoneId, QuotationId")]
        public QuotationZone QuotationZone { get; set; }
    }
}
