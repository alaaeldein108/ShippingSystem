using AutoMapper;
using Data.Entities.Addresses;
using Repositories.Interfaces;
using Repositories.Models;
using Services.AddressServices.ReceiverAddressBookService.Dto;

namespace Services.AddressServices.ReceiverAddressBookService
{
    public class ReceiverAddressBookService : IReceiverAddressBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceiverAddressBookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddReceiverAddressBookAsync(ReceiverAddressBookDto input)
        {
            var existingArea = await _unitOfWork.AreaRepository.GetAreaById(input.AreaId);
            if (existingArea == null)
            {
                throw new KeyNotFoundException($"Area with {input.ClientId} Not Exist.");
            }
            var existingClient = await _unitOfWork.ClientRepository.FindClientByIdAsync(input.ClientId);
            if (existingClient == null)
            {
                throw new KeyNotFoundException($"Client with {input.ClientId} Not Exist.");
            }
            var newReceiverAdd = _mapper.Map<ReceiverAddressBook>(input);
            await _unitOfWork.RecieverAddressBookRepository.AddRecieverAddressAsync(newReceiverAdd);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteReceiverAddressBook(int addressId)
        {
            var existingAddress = await _unitOfWork.RecieverAddressBookRepository.FindRecieverAddressBookByIdAsync(addressId);
            if (existingAddress == null)
            {
                throw new KeyNotFoundException($"Address with {addressId} Not Exist.");
            }
            _unitOfWork.RecieverAddressBookRepository.DeleteRecieverAddress(existingAddress);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<DataPage<ReceiverAddressBookDto>> GetAllReceiverAddressBookAsync(SearchCriteria input)
        {
            var addresses = await _unitOfWork.RecieverAddressBookRepository.GetRecieverAddressesAsync(input);

            var addressesDto = addresses.Data
                .Select(address => _mapper.Map<ReceiverAddressBookDto>(address))
                .AsQueryable();

            return new DataPage<ReceiverAddressBookDto>(addresses.PageIndex, addresses.PageSize, addresses.Count, addressesDto);
        }

        public async Task<ReceiverAddressBookDto> GetReceiverAddressBookByIdAsync(int addressId)
        {
            var existingAddress = await _unitOfWork.RecieverAddressBookRepository.FindRecieverAddressBookByIdAsync(addressId);
            if (existingAddress == null)
            {
                throw new KeyNotFoundException($"Address with {addressId} Not Exist.");
            }
            var AddressDto = _mapper.Map<ReceiverAddressBookDto>(existingAddress);
            return AddressDto;

        }

        public async Task UpdateReceiverAddressBook(ReceiverAddressBookDto input)
        {
            var existingAddress = await _unitOfWork.RecieverAddressBookRepository.FindRecieverAddressBookByIdAsync(input.Id.Value);
            if (existingAddress == null)
            {
                throw new KeyNotFoundException($"Address with {input.Id.Value} Not Exist.");
            }
            var existingArea = await _unitOfWork.AreaRepository.GetAreaById(input.AreaId);
            if (existingArea == null)
            {
                throw new KeyNotFoundException($"Area with {input.ClientId} Not Exist.");
            }
            var existingClient = await _unitOfWork.ClientRepository.FindClientByIdAsync(input.ClientId);
            if (existingClient == null)
            {
                throw new KeyNotFoundException($"Client with {input.ClientId} Not Exist.");
            }
            _mapper.Map(input, existingAddress);
            _unitOfWork.RecieverAddressBookRepository.UpdateRecieverAddress(existingAddress);

            await _unitOfWork.CompleteAsync();
        }
    }
}
