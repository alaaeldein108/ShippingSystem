using AutoMapper;
using Data.Entities.Operation;
using Services.OperationServices.BranchLevelService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.OperationMapping
{
    public class BranchLevelProfile:Profile
    {
        public BranchLevelProfile()
        {
            CreateMap<BranchLevel,BranchLevelDto>().ReverseMap();
        }
    }
}
