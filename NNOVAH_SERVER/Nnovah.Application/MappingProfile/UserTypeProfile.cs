using AutoMapper;
using Nnovah.Application.Features.UserType.Queries.GetUserType;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.MappingProfile
{
    public class UserTypeProfile : Profile
    {
        public UserTypeProfile()
        {
            CreateMap<UserTypeDTO, UserType>().ReverseMap();
        }
    }
}
