

using AutoMapper;
using Nnovah.Application.Features.Customer.Queries;
using Nnovah.Comunity.Domain;

namespace Nnovah.Application.MappingProfile
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer,CustomerDTO>().ReverseMap();
        }
    }
}
