using AutoMapper;
using Data.Entities.CustomerService.Abnormal;
using Services.CustomerServiceServices.AbnormalServices.AbnormalService.Dto;

namespace Services.Mapper.CustomerServiceMapping.AbnormalProfiles
{
    public class AbnormalProfile : Profile
    {
        public AbnormalProfile()
        {
            CreateMap<Abnormal, AbnormalDto>()
                .ForMember(dest => dest.AbnormalImages, opt => opt.Ignore())
                .ForMember(dest => dest.AbnormalReplies, opt => opt.Ignore()).ReverseMap();

            CreateMap<Abnormal, GetAbnormalDto>()
                .ForMember(dest => dest.WaybillNumber, opt => opt.MapFrom(src => src.Order.WaybillNumber))
                .ForMember(dest => dest.AbnormalMainReasonType, opt => opt.MapFrom(src => src.AbnormalSubReason.MainReason.Type))
                .ForMember(dest => dest.AbnormalSubReasonType, opt => opt.MapFrom(src => src.AbnormalSubReason.Type))
                .ForMember(dest => dest.CustomerCode, opt => opt.MapFrom(src => src.Order.ClientCode))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Order.Client.ClientName))
                .ForMember(dest => dest.RegisterName, opt => opt.MapFrom(src => src.Register.DisplayName))
                .ForMember(dest => dest.RegisterBranchName, opt => opt.MapFrom(src => src.Register.Branch.Name))
                .ForMember(dest => dest.RegisterationCentre, opt => opt.MapFrom(src => src.Register.Branch.Center))
                .ForMember(dest => dest.RegisterTime, opt => opt.MapFrom(src => src.RegisterTime))
                .ForMember(dest => dest.PickupTime, opt => opt.MapFrom(src => src.Order.PickupDate))
                .ForMember(dest => dest.RecievingBranchName, opt => opt.MapFrom(src => src.Order.PickupCourier.Branch.Name))
                .ForMember(dest => dest.RecievingCentreName, opt => opt.MapFrom(src => src.Order.PickupCourier.Branch.Center))
                .ForMember(dest => dest.IsSigned, opt => opt.MapFrom(src => src.Order.IsSigned))
                .ForMember(dest => dest.SignTime, opt => opt.MapFrom(src => src.Order.SigningDate))

                .ReverseMap();
        }
    }
}
