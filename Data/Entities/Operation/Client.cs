using Data.Entities.Addresses;
using Data.Entities.Enums;
using Data.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Operation
{
    public enum CustomerTypeEnum
    {
        Person = 1,
        Enterprise = 2
    }
    public class Client : BaseEntity
    {
        [Key]
        [MaxLength(50)]
        public string ClientCode { get; set; }
        [MaxLength(100)]
        public string ClientName { get; set; }
        [MaxLength(100)]
        public string ContactName { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public int? TaxNumber { get; set; }
        public int? CRNumber { get; set; }// السجل التجارى 
        [MaxLength(50)]
        public string? NationalId { get; set; }
        public CustomerTypeEnum CustomerType { get; set; }
        public BranchLevel CustomerBR { get; set; }
        [ForeignKey("CustomerBR")]
        public int CustomerBRId { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime? ContractStartTime { get; set; }
        public DateTime? ContractEndTime { get; set; }
        public Guid UserId { get; set; }
        public Area Address { get; set; }
        [MaxLength(50)]
        [ForeignKey("Address")]
        public string AddressId { get; set; }
        [MaxLength(200)]
        public string Street { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxCODAmount { get; set; } = 0; // اعلى رقم العميل يقدر يحط فلوس على الشحنة
        [MaxLength(100)]
        public string? BankName { get; set; }
        [MaxLength(200)]
        public string? BankAccountName { get; set; }
        [MaxLength(100)]
        public string? BankAccountNumber { get; set; }
        [MaxLength(50)]
        public string? WalletCash { get; set; }
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        public AppUser SalesPerson { get; set; }
        [ForeignKey("SalesPerson")]
        public Guid SalesPersonId { get; set; }
        public ChargeableWeightTypesEnum ChargeableWeight { get; set; }
        [MaxLength(200)]
        public string? ContractUrl { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<SenderAddressBook> SenderAddresses { get; set; } = new List<SenderAddressBook>();
        public ICollection<ReceiverAddressBook> ReceiverAddresses { get; set; } = new List<ReceiverAddressBook>();

    }

}
