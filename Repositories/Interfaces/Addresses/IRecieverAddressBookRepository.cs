using Data.Entities.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Addresses
{
    public interface IRecieverAddressBookRepository
    {
        Task AddRecieverAddressAsync(ReceiverAddressBook input);
        void UpdateRecieverAddress(ReceiverAddressBook input);
        void DeleteRecieverAddress(ReceiverAddressBook input);
        Task<ReceiverAddressBook> FindRecieverAddressBookByIdAsync(int id);
        Task<IQueryable<ReceiverAddressBook>> GetRecieverAddressesAsync();
    }
}
