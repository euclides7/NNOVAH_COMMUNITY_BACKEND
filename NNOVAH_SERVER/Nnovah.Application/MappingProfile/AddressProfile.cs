using AutoMapper;
using Nnovah.Comunity.Application.Features.Address.Commands.CreateAddress;
using Nnovah.Comunity.Application.Features.Address.Commands.UpdateAddress;
using Nnovah.Comunity.Application.Features.Address.Queries.GetAddress;
using Nnovah.Comunity.Application.Features.Contacts.Commands.UpdateContacts;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.MappingProfile
{
    public class AddressProfile:Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressComand,Address>().ReverseMap();
            CreateMap<AddressDTO,Address>().ReverseMap();
            CreateMap<UpdateAddressCommand,Address>().ReverseMap();
        }
    }
}
