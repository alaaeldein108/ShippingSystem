using AutoMapper;
using Data.Entities.CustomerService.Abnormal;
using Services.CustomerServiceServices.AbnormalServices.AbnormalService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.CustomerServiceMapping.AbnormalProfiles
{
    public class AbnormalProfile:Profile
    {
        public AbnormalProfile()
        {
            CreateMap<Abnormal, AbnormalDto>().ReverseMap();

        }
    }
}
