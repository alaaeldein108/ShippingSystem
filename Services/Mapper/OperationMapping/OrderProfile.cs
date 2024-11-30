using AutoMapper;
using Data.Entities.Operation;
using Services.OperationServices.OrderService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.OperationMapping
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order,OrderDto>().ReverseMap();
        }
    }
}
