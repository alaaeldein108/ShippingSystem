using AutoMapper;
using Data.Entities.Finance;
using Services.FinanceServices.CashFODCollectionService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.FinanceMapping
{
    public class CashFODCollectionProfile:Profile
    {
        public CashFODCollectionProfile()
        {
            CreateMap<Cash_FODCollection,CashFODCollectionDto>().ReverseMap();
        }
    }
}
