using AutoMapper;
using Data.Entities.Operation.Sorting;
using Services.OperationServices.SortingServices.FirstSegmentService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.OperationMapping.SortingProfiles
{
    public class FirstSegmentProfile:Profile
    {
        public FirstSegmentProfile()
        {
            CreateMap<FirstSegment,FirstSegmentDto>().ReverseMap();
        }
    }
}
