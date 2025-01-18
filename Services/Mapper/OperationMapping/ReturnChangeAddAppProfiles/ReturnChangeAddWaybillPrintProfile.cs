using AutoMapper;
using Data.Entities.Operation.Return_ChangeAdd;
using Services.OperationServices.Return_ChangeAddServices.ReturnChangeAddWaybillPrintService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.OperationMapping.ReturnChangeAddAppProfiles
{
    public class ReturnChangeAddWaybillPrintProfile:Profile
    {
        public ReturnChangeAddWaybillPrintProfile()
        {
            CreateMap<ReturnChangeAddWaybillPrint, ReturnChangeAddWaybillPrintDto>().ReverseMap();
        }
    }
}
