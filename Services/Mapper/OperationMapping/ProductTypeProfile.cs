using AutoMapper;
using Data.Entities.Operation;
using Services.OperationServices.ProductTypeService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.OperationMapping
{
    public class ProductTypeProfile:Profile
    {
        public ProductTypeProfile()
        {
            CreateMap<ProductType,ProductTypeDto>().ReverseMap();
        }
    }
}
