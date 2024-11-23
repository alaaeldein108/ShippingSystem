using Data.Entities.Enums;
using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Finance
{
    public enum AuditingEnum
    {
        Audited,
        Unaudited
    }
    public class Quotation:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BranchLevel AffailiatedBranch { get; set; }
        [ForeignKey("AffailiatedBranch")]
        public string AffailiatedBranchCode { get; set; }
        public LevelTypeEnum FinanceCentre { get; set; }
        public ProductType ProductType { get; set; }
        [ForeignKey("ProductType")]
        public string ProductTypeCode { get; set; }
        public StatusEnum EnableStatus { get; set; }
        public AuditingEnum Auditing { get; set; }= AuditingEnum.Unaudited;
        public DateTime ActivationStartTime { get; set; }
        public DateTime ActivationEndTime { get; set; }
        public QuotationTypeEnum QuotationType { get; set; }
        //COD Service Charge
        public decimal? LowestServiceCharge { get; set; }
        public decimal? HighestServiceCharge { get; set; }
        public ICollection<ClientQuotation> ClientQuotations { get; set; } = new List<ClientQuotation>();
        public ICollection<Quotation_Zone> QuotationZones { get; set; } = new List<Quotation_Zone>();

    }

}
