using AutoMapper;
using Data.Entities.CustomerService.Ticket;
using Services.CustomerServiceServices.TicketServices.TicketService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.CustomerServiceMapping.TicketProfiles
{
    public class TicketProfile:Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>();
        }
    }
}
