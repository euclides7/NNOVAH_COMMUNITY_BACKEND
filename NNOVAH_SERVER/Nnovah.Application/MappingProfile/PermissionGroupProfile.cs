using AutoMapper;
using Nnovah.Application.Features.PermissionGroup.Queries.GetPermissionGroup;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.MappingProfile
{
    public class PermissionGroupProfile:Profile
    {
        public PermissionGroupProfile()
        {
            CreateMap<PermissionGroup,PermissionGroupDTO>().ReverseMap();
        }
    }
}
