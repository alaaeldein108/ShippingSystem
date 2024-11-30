using AutoMapper;
using Data.Entities.Addresses;
using Services.AddressServices.ReceiverAddressBookService.Dto;
using Services.AddressServices.SenderAddressBookService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.AddressMapping
{
    public class SenderAddressBookProfile:Profile
    {
        public SenderAddressBookProfile()
        {
            CreateMap<SenderAddressBook, SenderAddressBookDto>().ReverseMap();

        }
    }
}
