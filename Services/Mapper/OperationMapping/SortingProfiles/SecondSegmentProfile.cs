using AutoMapper;
using Data.Entities.Operation.Sorting;
using Services.OperationServices.SortingServices.SecondSegmentService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.OperationMapping.SortingProfiles
{
    public class SecondSegmentProfile:Profile
    {
        public SecondSegmentProfile()
        {
            CreateMap<SecondSegment,SecondSegmentDto>().ReverseMap();
        }
    }
}
