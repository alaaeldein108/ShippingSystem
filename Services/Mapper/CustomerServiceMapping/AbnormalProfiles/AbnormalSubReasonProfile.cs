using AutoMapper;
using Services.CustomerServiceServices.AbnormalServices.AbnormalSubReasonService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.CustomerServiceMapping.AbnormalProfiles
{
    public class AbnormalSubReasonProfile:Profile
    {
        public AbnormalSubReasonProfile()
        {
            CreateMap<AbnormalSubReasonProfile,AbnormalSubReasonDto>().ReverseMap(); 
        }
    }
}
