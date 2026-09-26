

using AutoMapper;
using Nnovah.Application.Features.Partner.Queries.GetPartner;
using Nnovah.Comunity.Application.Contracts.Security;
using Nnovah.Comunity.Application.Features.Address.Queries.GetAddress;
using Nnovah.Comunity.Application.Features.Contacts.Queries.GetContacts;
using Nnovah.Comunity.Application.Features.Customer.Commands.CreateCustomer;
using Nnovah.Comunity.Application.Features.Customer.Commands.DeleteCustomer;
using Nnovah.Comunity.Application.Features.Customer.Commands.UpdateCustomer;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerDetail;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerQuery;
using Nnovah.Comunity.Application.MappingResolvers;
using Nnovah.Comunity.Domain;

namespace Nnovah.Application.MappingProfile
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>()
     .ForMember(dest => dest.EncryptedId,
                opt => opt.MapFrom<GenericIdResolver<Customer>>());
            CreateMap<Customer, CustomerDetailDTO>()
     .ForMember(dest => dest.EncryptedId,
                opt => opt.MapFrom<GenericIdResolver<Customer>>());
            CreateMap<Partner,PartnerDTO>().ReverseMap();
            CreateMap<Address,AddressDTO>().ReverseMap();
            CreateMap<Contacts,ContactsDTO>().ReverseMap();
            CreateMap<CreateCustomerCommand,Customer>().ReverseMap();
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<DeleteCustomerCommand, Customer>();
        }
    }
}
