using Data.Entities.Enums;
using Data.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Operation
{
    public enum CourierTypeEnum
    {
        PickupCourier = 1,
        DeliveryCourier = 2
    }
    public class CourierOrderScheduling
    {
        public AppUser Courier { get; set; }
        [ForeignKey("Courier")]
        public Guid CourierId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public Guid OrderNumber { get; set; }
        public CourierTypeEnum CourierType { get; set; }
        public AppUser Assigner { get; set; }
        [ForeignKey("Assigner")]
        public Guid AssignerId { get; set; }
        public DateTime AssignTime { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Active;
    }
}
