using Data.Entities.Addresses;
using Repositories.Models;

namespace Repositories.Interfaces.Addresses
{
    public interface ISenderAddressBookRepository
    {
        Task AddSenderAddressAsync(SenderAddressBook input);
        void UpdateSenderAddress(SenderAddressBook input);
        void DeleteSenderAddress(SenderAddressBook input);
        Task<SenderAddressBook> FindSenderAddressBookByIdAsync(int id);
        Task<DataPage<SenderAddressBook>> GetSenderAddressesAsync(SearchCriteria input);
    }
}
