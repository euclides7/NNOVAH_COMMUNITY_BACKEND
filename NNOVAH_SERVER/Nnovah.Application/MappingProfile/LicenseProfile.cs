using AutoMapper;
using Nnovah.Application.Features.License.Queries.GetLicense;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.MappingProfile
{
    public class LicenseProfile:Profile
    {
        public LicenseProfile()
        {
            CreateMap<License,LicenseDTO>().ReverseMap(); 
        }
    }
}
