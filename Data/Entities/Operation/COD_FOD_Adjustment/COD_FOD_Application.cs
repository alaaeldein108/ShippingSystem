using Data.Entities.Enums;
using Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Operation.COD_FOD_Adjustment
{
    public enum AdjustmentTypeEnum
    {
        COD,
        FOD
    }
    public enum ConfirmStatusEnum
    {
        Confirmed,
        UnConfirmed
    }
    public class COD_FOD_Application
    {
        public int Id { get; set; }
        public AdjustmentTypeEnum AdjustmentType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? FODBeforeAdjustment { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal? FODAfterAdjustment { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CODBeforeAdjustment { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CODAfterAdjustment { get; set; } = 0;
        public string? AdjustmentDescription { get; set; }
        public string RegisterId { get; set; }
        public DateTime RegisterTime { get; set; }
        public DateTime ConfirmedTime { get; set; }
        public string AuditorId { get; set; }
        public ConfirmStatusEnum ConfirmStatus { get; set; } = ConfirmStatusEnum.UnConfirmed;
        public string? ConfirmationDescription { get; set; }
        public StatusEnum Status { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public string OrderNumber { get; set; }

    }
}
