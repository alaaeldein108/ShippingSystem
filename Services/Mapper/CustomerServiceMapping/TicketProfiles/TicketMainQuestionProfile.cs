using AutoMapper;
using Data.Entities.CustomerService.Ticket;
using Services.CustomerServiceServices.TicketServices.TicketMainQuestionService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.CustomerServiceMapping.TicketProfiles
{
    public class TicketMainQuestionProfile:Profile
    {
        public TicketMainQuestionProfile()
        {
            CreateMap<TicketMainQuestion,TicketMainQuestionDto>().ReverseMap();
        }
    }
}
