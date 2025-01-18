using Data.Entities.Operation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Addresses
{
    public class SenderAddressBook : AddressBook
    {
        public Client Client { get; set; }
        [MaxLength(50)]
        [ForeignKey("Client")]
        public string ClientId { get; set; }
    }
}
