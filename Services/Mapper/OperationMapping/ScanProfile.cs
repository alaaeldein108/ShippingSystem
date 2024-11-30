using AutoMapper;
using Data.Entities.Operation;
using Services.OperationServices.ScanService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.OperationMapping
{
    public class ScanProfile:Profile
    {
        public ScanProfile()
        {
            CreateMap<Scan,ScanDto>().ReverseMap();
        }
    }
}
