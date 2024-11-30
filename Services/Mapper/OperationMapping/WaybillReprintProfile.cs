using AutoMapper;
using Data.Entities.Operation;
using Services.OperationServices.WaybillReprintService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.OperationMapping
{
    public class WaybillReprintProfile:Profile
    {
        public WaybillReprintProfile()
        {
            CreateMap<WaybillReprint,WaybillReprintDto>().ReverseMap();
        }
    }
}
