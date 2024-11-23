using Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Addresses;
using Data.Entities.Enums;
using Data.Entities.Finance;
using Data.Entities.Operation.COD_FOD_Adjustment;
using Data.Entities.Operation.Return_ChangeAdd;
using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Ticket;


namespace Data.Entities.Operation
{
    public enum OrderStatus
    {
        Printed,
        UnPrinted,
        PickedUp,
        Intransit,
        Delivering,
        Signed,
        Returning,
        Returned
    }
    public class Order
    {
        [Key]
        public string OrderNumber { get; set; }
        public string? WaybillNumber { get; set; }
        public string? ConnectedWaybill { get; set; }
        public string SenderName { get; set; }
        public string SenderPhone1 { get; set; }
        public string? SenderPhone2 { get; set; }
        public Area SenderAddress { get; set; }
        [ForeignKey("SenderAddress")]
        public string? SenderAddressId { get; set; }
        public string SenderStreet { get; set; }
        public string RecieverName { get; set; }
        public string RecieverPhone1 { get; set; }
        public string? RecieverPhone2 { get; set; }
        public Area RecieverAddress { get; set; }
        [ForeignKey("RecieverAddress")]
        public string? RecieverAddressId { get; set; }
        public string RecieverAreaName { get; set; }
        public string RecieverStreet { get; set; }
        public string? ClientOrderNo { get; set; }
        public int ItemWeight { get; set; }
        public ProductType ProductType { get; set; }
        [ForeignKey("ProductType")]
        public string ProductTypeCode { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.UnPrinted;

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
        public string? CustomerPickupInfo { get; set; }
        public Client Client { get; set; }
        [ForeignKey("Client")]
        public string? ClientCode { get; set; }
        public DateTime? PickupDate { get; set; }
        public string? OriginCenter { get; set; }
        public string? DeliveryCenter { get; set; }
        public BranchLevel PickupBR { get; set; }
        [ForeignKey("PickupBR")]
        public string? PickupBRId { get; set; }
        public BranchLevel DeliveryBR { get; set; }
        [ForeignKey("DeliveryBR")]
        public string? DeliveryBRId { get; set; }
        public BranchLevel SigningBR { get; set; }
        [ForeignKey("SigningBR")]
        public string? SigningBRId { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public DateTime? SigningTime { get; set; }

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
        public DateTime? LastUpdateTime { get; set; }
        public BranchLevel LastUpdateBR { get; set; }
        [ForeignKey("LastUpdateBR")]
        public string? LastUpdateBRId { get; set; }
        public string? TripleNumber { get; set; }
        public int? OFDTimes { get; set; }
        public SettlmentMethodEnum SettlmentMethod { get; set; }
        public  ICollection<Order_Scan> Order_Scans { get; set; } = new List<Order_Scan>();
        public ICollection<Abnormal>? Abnormals { get; set; } = new List<Abnormal>();
        public ICollection<Ticket>? Order_Tickets { get; set; } = new List<Ticket>();
        public ICollection<COD_FOD_Application>? COD_FOD_Apps { get; set; } = new List<COD_FOD_Application>();
        public Return_ChangeAdd_App? Return_ChangeAdd_App { get; set; }
        public COD_Collection? COD_Collection { get; set; }
        public Cash_FODCollection? Cash_FODCollection { get; set; }
    }

}
