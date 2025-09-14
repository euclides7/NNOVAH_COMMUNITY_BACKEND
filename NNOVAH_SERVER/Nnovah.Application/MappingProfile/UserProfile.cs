using AutoMapper;
using Nnovah.Application.Features.User.Queries.GetUser;
using Nnovah.Comunity.Domain;


namespace Nnovah.Application.MappingProfile
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserDTO>().ReverseMap();
        }
    }
}
