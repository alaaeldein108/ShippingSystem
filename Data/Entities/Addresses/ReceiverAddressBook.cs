using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Addresses
{
    public class ReceiverAddressBook : AddressBook
    {
        public Client Client { get; set; }
        [ForeignKey("Client")]
        public string ClientId { get; set; }
    }
}
