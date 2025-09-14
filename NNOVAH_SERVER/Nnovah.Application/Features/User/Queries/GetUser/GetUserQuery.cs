using MediatR;
using Nnovah.Application.Features.User.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.User.Queries.GetUser
{
    public record GetUserQuery : IRequest<List<UserDTO>>;
   
}
