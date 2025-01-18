using AutoMapper;
using Data.Entities.CustomerService.Abnormal;
using Repositories.Interfaces;
using Repositories.Models;
using Services.CustomerServiceServices.AbnormalServices.AbnormalSubReasonService.Dto;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalSubReasonService
{
    public class AbnormalSubReasonService : IAbnormalSubReasonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AbnormalSubReasonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAbnormalSubReasonAsync(AbnormalSubReasonDto input)
        {
            var existingMainReason = await _unitOfWork.AbnormalMainReasonRepository.FindAbnormalMainReasonAsync(input.MainReasonId);
            if (existingMainReason == null)
            {
                throw new KeyNotFoundException($"Abnormal Main Reason with {input.MainReasonId} Not Exist.");
            }

            var newSubReason = _mapper.Map<AbnormalSubReason>(input);
            newSubReason.CreatorId = input.CreatorId.Value;
            newSubReason.CreatedTime = DateTime.Now;
            newSubReason.Status = Data.Entities.Enums.StatusEnum.Active;
            await _unitOfWork.AbnormalSubReasonRepository.AddAbnormalSubReasonAsync(newSubReason);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAbnormalSubReason(int id)
        {
            var existingAbnormal = await _unitOfWork.AbnormalSubReasonRepository.FindAbnormalSubReasonAsync(id);
            if (existingAbnormal == null)
            {
                throw new KeyNotFoundException($"Abnormal Sub Reason with {id} Not Exist.");
            }
            existingAbnormal.Status = Data.Entities.Enums.StatusEnum.InActive;
            _unitOfWork.AbnormalSubReasonRepository.UpdateAbnormalSubReason(existingAbnormal);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<AbnormalSubReasonDto> GetAbnormalSubReasonIdAsync(int id)
        {
            var existingAbnormal = await _unitOfWork.AbnormalSubReasonRepository.FindAbnormalSubReasonAsync(id);
            if (existingAbnormal == null)
            {
                throw new KeyNotFoundException($"Abnormal Sub Reason with {id} Not Exist.");
            }
            var abnormalSubReasonDto = _mapper.Map<AbnormalSubReasonDto>(existingAbnormal);
            return abnormalSubReasonDto;
        }

        public async Task<DataPage<AbnormalSubReasonDto>> GetAllAbnormalSubReasonAsync(SearchCriteria input)
        {
            var subReasons = await _unitOfWork.AbnormalSubReasonRepository.GetAllAbnormalSubReasonsAsync(input);

            var subReasonsDto = subReasons.Data
                .Select(subnReason => _mapper.Map<AbnormalSubReasonDto>(subnReason))
                .AsQueryable();

            return new DataPage<AbnormalSubReasonDto>(subReasons.PageIndex, subReasons.PageSize, subReasons.Count, subReasonsDto);
        }

        public async Task UpdateAbnormalSubReason(AbnormalSubReasonDto input)
        {
            var existingAbnormal = await _unitOfWork.AbnormalSubReasonRepository.FindAbnormalSubReasonAsync(input.Id.Value);
            if (existingAbnormal == null)
            {
                throw new KeyNotFoundException($"Abnormal Sub Reason with {input.Id.Value} Not Exist.");
            }
            var existingAbnormalMainReason = await _unitOfWork.AbnormalMainReasonRepository.FindAbnormalMainReasonAsync(input.MainReasonId);
            if (existingAbnormal == null)
            {
                throw new KeyNotFoundException($"Abnormal Main Reason with {input.MainReasonId} Not Exist.");
            }
            _mapper.Map(input, existingAbnormal);
            existingAbnormal.UpdatorId = input.UpdatorId;
            existingAbnormal.ModificationTime = input.ModificationTime;
            _unitOfWork.AbnormalSubReasonRepository.UpdateAbnormalSubReason(existingAbnormal);

            await _unitOfWork.CompleteAsync();
        }
    }
}
