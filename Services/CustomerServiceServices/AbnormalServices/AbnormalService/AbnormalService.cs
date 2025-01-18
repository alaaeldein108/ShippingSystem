using AutoMapper;
using Data.Entities.CustomerService.Abnormal;
using Data.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Repositories.Interfaces;
using Repositories.Models;
using Services.CustomerServiceServices.AbnormalServices.AbnormalService.Dto;
using Services.FileService;
using SixLabors.ImageSharp;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalService
{
    public class AbnormalService : IAbnormalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<AppUser> _userManager;

        public AbnormalService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService
            , UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
            _userManager = userManager;
        }
        public async Task AddAbnormalAsync(AbnormalDto input, Guid creatorId)
        {
            var abnormalSubReason = await _unitOfWork.AbnormalSubReasonRepository.FindAbnormalSubReasonAsync(input.AbnormalSubReasonId);
            if (abnormalSubReason == null)
            {
                throw new KeyNotFoundException($"AbnormalSubReason with ID {input.AbnormalSubReasonId} does not exist.");
            }
            var order = await _unitOfWork.OrderRepository.FindOrderByIdAsync(input.OrderNumber);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {input.OrderNumber} does not exist.");
            }
            var abnormal = _mapper.Map<Abnormal>(input);
            abnormal.RegisterTime = DateTime.UtcNow;

            if (input.AbnormalImages != null && input.AbnormalImages.Any())
            {
                var pictureUrls = await _fileService.SavePicturesAsync(input.AbnormalImages, "CustomerService", "Abnormal");
                var abnormalImages = pictureUrls.Select(url => new AbnormalImages
                {
                    PictureUrl = url,
                    Abnormal = abnormal
                }).ToList();
                await _unitOfWork.AbnormalImagesRepository.AddAbnormalImages(abnormalImages, order.OrderNumber, creatorId);
            }
            await _unitOfWork.AbnormalRepository.AddAbnormalAsync(abnormal);
            await _unitOfWork.CompleteAsync();


        }

        public async Task<GetAbnormalDto> FindAbnormalById(Guid Number)
        {
            var abnormal = await _unitOfWork.AbnormalRepository.FindAbnormalById(Number);

            if (abnormal == null)
            {
                throw new KeyNotFoundException($"Abnormal with Number {Number} does not exist.");
            }

            var abnormalDto = _mapper.Map<GetAbnormalDto>(abnormal);

            var abnormalImages = await _unitOfWork.AbnormalImagesRepository
                .GetAllAbnormalImagesByAbnormalNumberAsync(Number);
            abnormalDto.AbnormalImages = abnormalImages.Select(x => x.PictureUrl).ToList();

            var abnormalReplies = await _unitOfWork.AbnormalReplyRepository
                .GetAllAbnormalReplyiesByAbnormalNumberAsync(Number);

            abnormalDto.AbnormalReplies = abnormalReplies.Select(reply => new AbnormalReply
            {
                Id = reply.Id,
                ReplyText = reply.ReplyText,
                ReplierId = reply.ReplierId,
                ReplyTime = reply.ReplyTime,
                ReplyImages = reply.ReplyImages.Select(image => new AbnormalReplyImages
                {
                    ReplyId = image.ReplyId,
                    PictureUrl = image.PictureUrl
                }).ToList()
            }).ToList();

            return abnormalDto;
        }

        public async Task<DataPage<GetAbnormalDto>> GetAllAbnormalsAsync(SearchCriteria input)
        {

            throw new NotImplementedException();


        }

        public Task UpdateAbnormal(AbnormalDto input, Guid creatorId)
        {
            throw new NotImplementedException();
        }
    }
}
