using Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Enums;
using Data.Entities.Addresses;
using Data.Entities.Finance;

namespace Data.Entities.Operation
{
    public enum CustomerTypeEnum
    {
        Person,
        Enterprise
    }
    public class Client:BaseEntity
    {
        [Key]
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public int? TaxNumber { get; set; }
        public int? CRNumber { get; set; }// السجل التجارى 
        public string? NationalId { get; set; }
        public CustomerTypeEnum CustomerType { get; set; }
        public BranchLevel CustomerBR { get; set; }
        [ForeignKey("CustomerBR")]
        public string CustomerBRId { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime? ContractStartTime { get; set; }
        public DateTime? ContractEndTime { get; set; }
        public Area Address { get; set; }
        [ForeignKey("Address")]
        public string? AddressId { get; set; }
        public string? Street { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaxCODAmount { get; set; } = 0; // اعلى رقم العميل يقدر يحط فلوس على الشحنة
        public string? BankName { get; set; }
        public string? BankAccountName { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? WalletCash { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? SalesPersonId { get; set; }
        public ChargeableWeightTypesEnum ChargeableWeight { get; set; }
        public string? ContractUrl { get; set; } // الملف اللى فيه العقد
        public  ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<ClientQuotation> ClientQuotations { get; set; } = new List<ClientQuotation>();
        public ICollection<SenderAddressBook> SenderAddresses { get; set; } = new List<SenderAddressBook>();
        public ICollection<ReceiverAddressBook> ReceiverAddresses { get; set; } = new List<ReceiverAddressBook>();

    }

}
