using AutoMapper;
using Data.Entities.Operation.COD_FOD_Adjustment;
using Services.OperationServices.COD_FOD_ApplicationService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.OperationMapping
{
    public class CODFODApplicationProfile:Profile
    {
        public CODFODApplicationProfile()
        {
            CreateMap<COD_FOD_Application, CODFODApplicationDto>().ReverseMap();
        }
    }
}
