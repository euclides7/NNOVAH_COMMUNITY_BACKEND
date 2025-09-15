using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.User.Queries.GetUserDetailsQuery
{
    public record GetUserDetailsQuery(int id) : IRequest<UserDetailsDTO>;

}
