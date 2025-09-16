

using AutoMapper;
using Nnovah.Application.Features.Customer.Queries;
using Nnovah.Comunity.Application.Features.Customer.Commands.CreateCustomer;
using Nnovah.Comunity.Domain;

namespace Nnovah.Application.MappingProfile
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer,CustomerDTO>().ReverseMap();
            CreateMap<CreateCustomerCommand,Customer>().ReverseMap();
        }
    }
}
