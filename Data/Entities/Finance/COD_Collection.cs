using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Finance
{
    public enum CollectionEnum
    {
        Uncollected,
        Collected
    }
    public class COD_Collection
    {
        [Key]
        public string BillNumber { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public CollectionEnum CODCollectionStatus { get; set; } = CollectionEnum.Uncollected;
        public DateTime? CollectionTime { get; set; }
        public string CollectorId { get; set; }
    }
}
