using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Finance
{
    public enum PaymentCollectionTypeEnum
    {
        Cash = 1,
        FOD = 2
    }
    public class CashFODCollection
    {
        [Key]
        public Guid BillNumber { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public CollectionEnum CashFODCollectionStatus { get; set; } = CollectionEnum.Uncollected;
        public PaymentCollectionTypeEnum Payment_CollectionType { get; set; }
        public DateTime? CollectionTime { get; set; }
        public AppUser Collector { get; set; }
        [ForeignKey("Collector")]
        public Guid CollectorId { get; set; }
    }
}
