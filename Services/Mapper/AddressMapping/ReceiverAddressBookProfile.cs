using AutoMapper;
using Data.Entities.Addresses;
using Services.AddressServices.ReceiverAddressBookService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.AddressMapping
{
    public class ReceiverAddressBookProfile:Profile
    {
        public ReceiverAddressBookProfile()
        {
            CreateMap<ReceiverAddressBook, ReceiverAddressBookDto>().ReverseMap();
        }
    }
}
