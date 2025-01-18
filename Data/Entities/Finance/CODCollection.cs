using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Finance
{
    public enum CollectionEnum
    {
        Uncollected = 1,
        Collected = 2,
        PartialCollected = 3
    }
    public class CODCollection
    {
        [Key]
        public Guid BillNumber { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public CollectionEnum CODCollectionStatus { get; set; } = CollectionEnum.Uncollected;
        public DateTime? CollectionTime { get; set; }
        public AppUser Collector { get; set; }
        [ForeignKey("Collector")]
        public Guid CollectorId { get; set; }
    }
}
