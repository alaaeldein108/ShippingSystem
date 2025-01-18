using AutoMapper;
using Data.Entities.CustomerService.Abnormal;
using Repositories.Interfaces;
using Repositories.Models;
using Services.FinanceServices.ZoneService.Dto;

namespace Services.FinanceServices.ZoneService
{
    public class ZoneService : IZoneService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ZoneService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddZoneAsync(ZoneDto input)
        {
            var existingBranch = await unitOfWork.BranchLevelRepository.FindBranchLevelByIdAsync(input.AffailiatedBranchId);
            if (existingBranch == null)
            {
                throw new KeyNotFoundException($"Branch with {input.AffailiatedBranchId} Not Exist.");
            }
            foreach (var city in input.Cities)
            {
                var cityExist = await unitOfWork.CityRepository.GetCityById(city);
                if (cityExist is null)
                {
                    throw new KeyNotFoundException($"City with ID {city} not found.");
                }
                else
                {

                }
            }
            var newSubReason = mapper.Map<AbnormalSubReason>(input);
            newSubReason.CreatorId = input.CreatorId.Value;
            newSubReason.CreatedTime = DateTime.Now;
            newSubReason.Status = Data.Entities.Enums.StatusEnum.Active;
            await unitOfWork.AbnormalSubReasonRepository.AddAbnormalSubReasonAsync(newSubReason);

            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteZone(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DataPage<ZoneDto>> GetAllZonesAsync(ZonePagination input)
        {
            throw new NotImplementedException();
        }

        public async Task<ZoneDto> GetZoneIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateZone(ZoneDto input)
        {
            throw new NotImplementedException();
        }
    }
}
