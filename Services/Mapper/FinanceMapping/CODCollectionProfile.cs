using AutoMapper;
using Data.Entities.Finance;
using Services.FinanceServices.CODCollectionService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.FinanceMapping
{
    public class CODCollectionProfile:Profile
    {
        public CODCollectionProfile()
        {
            CreateMap<COD_Collection,CODCollectionDto>().ReverseMap();
        }
    }
}
