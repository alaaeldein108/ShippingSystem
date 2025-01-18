using Data.Entities.Addresses;
using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Ticket;
using Data.Entities.Enums;
using Data.Entities.IdentityEntities;
using Data.Entities.Operation.COD_FOD_Adjustment;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities.Operation
{
    public enum ClientOrderStatusEnum
    {
        Printed = 1,
        NonPickedUp = 1,
        UnPrinted = 2,
        Cancelled = 3,
        PickedUp = 4,
        Intransit = 5,
        Delivering = 6,
        Signed = 7,
        Returning = 8,
        Returned = 9
    }
    public enum OrderSourceEnum
    {
        System = 1,
        CourierApp = 2,
        OfficialWebsite = 3,
        CallCentre = 4,
        CustomerApp = 5
    }
    public class Order
    {
        [Key]
        public Guid OrderNumber { get; set; }
        [MaxLength(50)]
        public string? WaybillNumber { get; set; }
        [MaxLength(50)]
        public string? ConnectedWaybill { get; set; }
        [MaxLength(100)]
        public string SenderName { get; set; }
        [MaxLength(50)]
        public string SenderPhone1 { get; set; }
        [MaxLength(50)]
        public string? SenderPhone2 { get; set; }
        public Area SenderAddress { get; set; }
        [MaxLength(50)]
        [ForeignKey("SenderAddress")]
        public string SenderAddressId { get; set; }
        [MaxLength(200)]
        public string SenderStreet { get; set; }
        [MaxLength(100)]
        public string RecieverName { get; set; }
        [MaxLength(50)]
        public string RecieverPhone1 { get; set; }
        [MaxLength(50)]
        public string? RecieverPhone2 { get; set; }
        public Area RecieverAddress { get; set; }
        [MaxLength(50)]
        [ForeignKey("RecieverAddress")]
        public string RecieverAddressId { get; set; }
        public string RecieverStreet { get; set; }
        public int ItemWeight { get; set; }
        public ProductType ProductType { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public OrderSourceEnum OrderSource { get; set; }
        public ClientOrderStatusEnum OrderStatus { get; set; } = ClientOrderStatusEnum.UnPrinted;
        public AppUser PickupCourier { get; set; }
        [ForeignKey("PickupCourier")]
        public Guid? PickupCourierId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? PickupDate { get; set; }
        public AppUser SigningCourier { get; set; }
        [ForeignKey("SigningCourier")]
        public Guid? SigningCourierId { get; set; }
        public DateTime? SigningDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeliveryFees { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal COD { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal CODFees { get; set; } = 0;
        public bool Insured { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal InsuranceValue { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal InsuranceValueFees { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal ChangeAddFees { get; set; } = 0;
        public int? CustomerPickupNo { get; set; }
        [MaxLength(500)]
        public string? CustomerPickupInfo { get; set; }
        public Client Client { get; set; }
        [MaxLength(50)]
        [ForeignKey("Client")]
        public string? ClientCode { get; set; }
        public string? ClientOrderNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AdditionalFees { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalFees { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal FOD { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal FODFees { get; set; } = 0;
        public SignStatusEnum IsSigned { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Length { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Width { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Height { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal VolumeWeight { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal PickupWeight { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal InboundWeight { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal HubWeight { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal InternalWeight { get; set; } = 0;
        public VoidedStatusEnum Voided { get; set; } = VoidedStatusEnum.UnVoided;
        [MaxLength(50)]
        public string? TripleNumber { get; set; }
        public int? OFDTimes { get; set; }
        public SettlmentMethodEnum SettlmentMethod { get; set; }
        public ICollection<OrderScan> OrderScans { get; set; } = new List<OrderScan>();
        public ICollection<Abnormal>? Abnormals { get; set; } = new List<Abnormal>();
        public ICollection<Ticket>? OrderTickets { get; set; } = new List<Ticket>();
        public ICollection<CourierOrderScheduling>? CourierOrders { get; set; } = new List<CourierOrderScheduling>();
        public ICollection<CODFODAdjustmentApp>? CODFODApps { get; set; } = new List<CODFODAdjustmentApp>();
    }

}
