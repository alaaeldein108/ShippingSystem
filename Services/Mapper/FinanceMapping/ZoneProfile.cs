using AutoMapper;
using Data.Entities.Finance;
using Services.FinanceServices.ZoneService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.FinanceMapping
{
    public class ZoneProfile:Profile
    {
        public ZoneProfile()
        {
            CreateMap<Zone,ZoneDto>().ReverseMap();
        }
    }
}
