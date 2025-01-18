using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Finance
{
    public class QuotationZone
    {
        public Zone Zone { get; set; }
        [ForeignKey("Zone")]
        public int ZoneId { get; set; }
        public Quotation Quotation { get; set; }
        [ForeignKey("Quotation")]
        public int QuotationId { get; set; }
        [MaxLength(200)]
        public string TierName { get; set; }
        public ICollection<Formula> Formulas { get; set; } = new List<Formula>();

    }

}
