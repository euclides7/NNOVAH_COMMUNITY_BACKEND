using MediatR;
using Nnovah.Application.Features.User.Queries.GetUser;
using Nnovah.Comunity.Application.Features.User.Queries.GetUserLoginQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.User.Queries.GetUserLogin
{
    public record GetUserLoginQuery(int idPartner,string userCode, string password) : IRequest<LoginDTO>;
     
}
