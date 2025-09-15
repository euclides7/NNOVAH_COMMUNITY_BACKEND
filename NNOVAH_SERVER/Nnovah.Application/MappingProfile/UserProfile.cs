using AutoMapper;
using Nnovah.Application.Features.User.Queries.GetUser;
using Nnovah.Comunity.Application.Features.User.Commands.CreateUser;
using Nnovah.Comunity.Application.Features.User.Queries.GetUserDetailsQuery;
using Nnovah.Comunity.Application.Features.User.Queries.GetUserLoginQuery;
using Nnovah.Comunity.Domain;


namespace Nnovah.Application.MappingProfile
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<User, LoginDTO>().ReverseMap();
            CreateMap<User,UserDetailsDTO>().ReverseMap();
            CreateMap<CreateUserCommand, User>().ReverseMap();
        }
    }
}
