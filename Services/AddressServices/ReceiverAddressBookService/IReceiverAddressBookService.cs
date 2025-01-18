using Repositories.Models;
using Services.AddressServices.ReceiverAddressBookService.Dto;

namespace Services.AddressServices.ReceiverAddressBookService
{
    public interface IReceiverAddressBookService
    {
        Task AddReceiverAddressBookAsync(ReceiverAddressBookDto input);
        Task UpdateReceiverAddressBook(ReceiverAddressBookDto input);
        Task<DataPage<ReceiverAddressBookDto>> GetAllReceiverAddressBookAsync(SearchCriteria input);
        Task DeleteReceiverAddressBook(int addressId);
        Task<ReceiverAddressBookDto> GetReceiverAddressBookByIdAsync(int addressId);
    }
}
