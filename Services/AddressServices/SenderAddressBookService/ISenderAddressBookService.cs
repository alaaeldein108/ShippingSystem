using Repositories.Models;
using Services.AddressServices.SenderAddressBookService.Dto;

namespace Services.AddressServices.SenderAddressBookService
{
    public interface ISenderAddressBookService
    {
        Task AddSenderAddressBookAsync(SenderAddressBookDto input);
        Task UpdateSenderAddressBook(SenderAddressBookDto input);
        Task<DataPage<SenderAddressBookDto>> GetAllSenderAddressBookAsync(SearchCriteria input);
        Task DeleteSenderAddressBook(int addressId);
        Task<SenderAddressBookDto> GetSenderAddressBookByIdAsync(int addressId);
    }
}
