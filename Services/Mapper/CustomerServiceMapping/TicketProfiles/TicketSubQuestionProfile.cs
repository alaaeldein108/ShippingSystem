using AutoMapper;
using Data.Entities.CustomerService.Ticket;
using Services.CustomerServiceServices.TicketServices.TicketSubQuestionService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.CustomerServiceMapping.TicketProfiles
{
    public class TicketSubQuestionProfile:Profile
    {
        public TicketSubQuestionProfile()
        {
            CreateMap<TicketSubQuestion, TicketSubQuestionDto>().ReverseMap();
        }
    }
}
