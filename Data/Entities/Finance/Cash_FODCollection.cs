using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Finance
{
    public enum PaymentCollectionTypeEnum
    {
        Cash,
        FOD
    }
    public class Cash_FODCollection
    {
        [Key]
        public string BillNumber { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public CollectionEnum Cash_FODCollectionStatus { get; set; } = CollectionEnum.Uncollected;
        public PaymentCollectionTypeEnum Payment_CollectionType { get; set; }
        public DateTime? CollectionTime { get; set; }
        public string CollectorId { get; set; }
    }
}
