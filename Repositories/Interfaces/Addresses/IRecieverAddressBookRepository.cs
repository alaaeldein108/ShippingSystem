using Data.Entities.Addresses;
using Repositories.Models;

namespace Repositories.Interfaces.Addresses
{
    public interface IRecieverAddressBookRepository
    {
        Task AddRecieverAddressAsync(ReceiverAddressBook input);
        void UpdateRecieverAddress(ReceiverAddressBook input);
        void DeleteRecieverAddress(ReceiverAddressBook input);
        Task<ReceiverAddressBook> FindRecieverAddressBookByIdAsync(int id);
        Task<DataPage<ReceiverAddressBook>> GetRecieverAddressesAsync(SearchCriteria input);
    }
}
