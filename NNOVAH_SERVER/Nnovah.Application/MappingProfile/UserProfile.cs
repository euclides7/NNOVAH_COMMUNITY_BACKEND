using AutoMapper;
using Nnovah.Application.Features.User.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.MappingProfile
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserProfile,UserDTO>().ReverseMap();
        }
    }
}
