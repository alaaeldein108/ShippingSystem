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
    public class Zone:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ZoneTypeEnum ZoneType { get; set; }
        public BranchLevel AffailiatedBranch { get; set; }
        [ForeignKey("AffailiatedBranch")]
        public string AffailiatedBranchCode { get; set; }
        public string OriginsOrDestinations { get; set; }
        public QuotationTypeEnum QuotationType { get; set; }
        public  ICollection<Quotation_Zone> QuotationZones { get; set; } = new List<Quotation_Zone>();

    }

}
