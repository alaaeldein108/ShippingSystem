using AutoMapper;
using Data.Entities.Addresses;
using Repositories.Interfaces;
using Repositories.Models;
using Services.AddressServices.SenderAddressBookService.Dto;

namespace Services.AddressServices.SenderAddressBookService
{
    public class SenderAddressBookService : ISenderAddressBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SenderAddressBookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddSenderAddressBookAsync(SenderAddressBookDto input)
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
            var newSenderAdd = _mapper.Map<SenderAddressBook>(input);
            await _unitOfWork.SenderAddressBookRepository.AddSenderAddressAsync(newSenderAdd);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteSenderAddressBook(int addressId)
        {
            var existingAddress = await _unitOfWork.SenderAddressBookRepository.FindSenderAddressBookByIdAsync(addressId);
            if (existingAddress == null)
            {
                throw new KeyNotFoundException($"Address with {addressId} Not Exist.");
            }
            _unitOfWork.SenderAddressBookRepository.DeleteSenderAddress(existingAddress);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<DataPage<SenderAddressBookDto>> GetAllSenderAddressBookAsync(SearchCriteria input)
        {
            var addresses = await _unitOfWork.SenderAddressBookRepository.GetSenderAddressesAsync(input);

            var addressesDto = addresses.Data
               .Select(address => _mapper.Map<SenderAddressBookDto>(address))
               .AsQueryable();

            return new DataPage<SenderAddressBookDto>(addresses.PageIndex, addresses.PageSize, addresses.Count, addressesDto);
        }

        public async Task<SenderAddressBookDto> GetSenderAddressBookByIdAsync(int addressId)
        {
            var existingAddress = await _unitOfWork.SenderAddressBookRepository.FindSenderAddressBookByIdAsync(addressId);
            if (existingAddress == null)
            {
                throw new KeyNotFoundException($"Address with {addressId} Not Exist.");
            }
            var AddressDto = _mapper.Map<SenderAddressBookDto>(existingAddress);
            return AddressDto;
        }

        public async Task UpdateSenderAddressBook(SenderAddressBookDto input)
        {
            var existingAddress = await _unitOfWork.SenderAddressBookRepository.FindSenderAddressBookByIdAsync(input.Id.Value);
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
            _unitOfWork.SenderAddressBookRepository.UpdateSenderAddress(existingAddress);

            await _unitOfWork.CompleteAsync();

        }
    }
}
