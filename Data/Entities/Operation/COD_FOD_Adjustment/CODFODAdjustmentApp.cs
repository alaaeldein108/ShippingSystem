using Data.Entities.Enums;
using Data.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Operation.COD_FOD_Adjustment
{
    public enum AdjustmentTypeEnum
    {
        COD = 1,
        FOD = 2
    }
    public enum ConfirmStatusEnum
    {
        UnConfirmed = 1,
        Confirmed = 2,
    }
    public class CODFODAdjustmentApp
    {
        public Guid Id { get; set; }
        public AdjustmentTypeEnum AdjustmentType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? FODBeforeAdjustment { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CODBeforeAdjustment { get; set; } = 0;
        [MaxLength(500)]
        public string? AdjustmentDescription { get; set; }
        public AppUser Register { get; set; }
        [ForeignKey("Register")]
        public Guid RegisterId { get; set; }
        public DateTime RegisterTime { get; set; }
        public DateTime ConfirmedTime { get; set; }
        public AppUser Auditor { get; set; }
        [ForeignKey("Auditor")]
        public Guid AuditorId { get; set; }
        public ConfirmStatusEnum ConfirmStatus { get; set; } = ConfirmStatusEnum.UnConfirmed;
        [MaxLength(500)]
        public string? ConfirmationDescription { get; set; }
        public StatusEnum Status { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public Guid OrderNumber { get; set; }

    }
}
