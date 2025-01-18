using Data.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Operation
{
    public class OrderScan
    {
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public Guid OrderNumber { get; set; }
        public Scan Scan { get; set; }
        [ForeignKey("Scan")]
        public int ScanId { get; set; }
        public DateTime? ScanTime { get; set; }
        public AppUser Scanner { get; set; }
        [ForeignKey("Scanner")]
        public Guid ScannerId { get; set; }
        public int? NextBranchId { get; set; }
    }
}
