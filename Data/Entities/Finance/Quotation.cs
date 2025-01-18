using Data.Entities.Enums;
using Data.Entities.Operation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Finance
{
    public enum AuditingEnum
    {
        Unaudited = 1,
        Audited = 2,
    }
    public class Quotation : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public Client Client { get; set; }
        [MaxLength(50)]
        [ForeignKey("Client")]
        public string ClientCode { get; set; }
        public LevelTypeEnum FinanceCentre { get; set; }
        public ProductType ProductType { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public StatusEnum Status { get; set; }
        public AuditingEnum Auditing { get; set; } = AuditingEnum.Unaudited;
        public DateTime ActivationStartTime { get; set; }
        public DateTime ActivationEndTime { get; set; }
        public QuotationTypeEnum QuotationType { get; set; }
        //COD Service Charge
        public decimal? LowestServiceCharge { get; set; }
        public decimal? HighestServiceCharge { get; set; }
        public ICollection<QuotationZone> QuotationZones { get; set; } = new List<QuotationZone>();

    }

}
