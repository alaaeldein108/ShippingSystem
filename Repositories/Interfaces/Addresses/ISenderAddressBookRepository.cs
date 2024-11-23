using Data.Entities.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Addresses
{
    public interface ISenderAddressBookRepository
    {
        Task AddSenderAddressAsync(SenderAddressBook input);
        void UpdateSenderAddress(SenderAddressBook input);
        void DeleteSenderAddress(SenderAddressBook input);
        Task<IEnumerable<SenderAddressBook>> FindSenderAddressesByClientCodeAsync(string clientId);
    }
}
