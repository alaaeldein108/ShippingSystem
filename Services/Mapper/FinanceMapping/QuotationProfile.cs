using AutoMapper;
using Data.Entities.Finance;
using Services.FinanceServices.QuotationService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.FinanceMapping
{
    public class QuotationProfile:Profile
    {
        public QuotationProfile()
        {
            CreateMap<Quotation, QuotationDto>().ReverseMap();
        }
    }
}
