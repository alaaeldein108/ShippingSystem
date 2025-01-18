using AutoMapper;
using Data.Entities.CustomerService.Abnormal;
using Repositories.Interfaces;
using Repositories.Models;
using Services.CustomerServiceServices.AbnormalServices.AbnormalMainReasonService.Dto;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalMainReasonService
{
    public class AbnormalMainReasonService : IAbnormalMainReasonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AbnormalMainReasonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAbnormalMainReasonAsync(AbnormalMainReasonDto input)
        {

            var newMainReason = _mapper.Map<AbnormalMainReason>(input);
            newMainReason.CreatorId = input.CreatorId.Value;
            newMainReason.CreatedTime = DateTime.Now;
            newMainReason.Status = Data.Entities.Enums.StatusEnum.Active;
            await _unitOfWork.AbnormalMainReasonRepository.AddAbnormalMainReasonAsync(newMainReason);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAbnormalMainReason(int id)
        {
            var existingAbnormal = await _unitOfWork.AbnormalMainReasonRepository.FindAbnormalMainReasonAsync(id);
            if (existingAbnormal == null)
            {
                throw new KeyNotFoundException($"Abnormal Main Reason with {id} Not Exist.");
            }
            existingAbnormal.Status = Data.Entities.Enums.StatusEnum.InActive;
            _unitOfWork.AbnormalMainReasonRepository.UpdateAbnormalMainReason(existingAbnormal);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<AbnormalMainReasonDto> GetAbnormalMainReasonIdAsync(int id)
        {
            var existingAbnormal = await _unitOfWork.AbnormalMainReasonRepository.FindAbnormalMainReasonAsync(id);
            if (existingAbnormal == null)
            {
                throw new KeyNotFoundException($"Abnormal Main Reason with {id} Not Exist.");
            }
            var abnormalMainReasonDto = _mapper.Map<AbnormalMainReasonDto>(existingAbnormal);
            return abnormalMainReasonDto;
        }

        public async Task<DataPage<AbnormalMainReasonDto>> GetAllAbnormalMainReasonAsync(SearchCriteria input)
        {
            var mainReasons = await _unitOfWork.AbnormalMainReasonRepository.GetAllAbnormalMainReasonsAsync(input);

            var mainReasonsDto = mainReasons.Data
                .Select(mainReason => _mapper.Map<AbnormalMainReasonDto>(mainReason))
                .AsQueryable();

            return new DataPage<AbnormalMainReasonDto>(mainReasons.PageIndex, mainReasons.PageSize, mainReasons.Count, mainReasonsDto);
        }

        public async Task UpdateAbnormalMainReason(AbnormalMainReasonDto input)
        {
            var existingAbnormal = await _unitOfWork.AbnormalMainReasonRepository.FindAbnormalMainReasonAsync(input.Id.Value);
            if (existingAbnormal == null)
            {
                throw new KeyNotFoundException($"Abnormal Main Reason with {input.Id.Value} Not Exist.");
            }

            _mapper.Map(input, existingAbnormal);
            existingAbnormal.UpdatorId = input.UpdatorId;
            existingAbnormal.ModificationTime = input.ModificationTime;
            _unitOfWork.AbnormalMainReasonRepository.UpdateAbnormalMainReason(existingAbnormal);

            await _unitOfWork.CompleteAsync();
        }
    }
}
