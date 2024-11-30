using AutoMapper;
using Data.Entities.CustomerService.Abnormal;
using Services.CustomerServiceServices.AbnormalServices.AbnormalReplyService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.CustomerServiceMapping.AbnormalProfiles
{
    public class AbnormalReplyProfile:Profile
    {
        public AbnormalReplyProfile()
        {
            CreateMap<AbnormalReply,AbnormalReplyDto>().ReverseMap();
        }
    }
}
