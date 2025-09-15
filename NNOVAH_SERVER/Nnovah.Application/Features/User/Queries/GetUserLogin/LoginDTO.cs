using Nnovah.Application.Features.User.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.User.Queries.GetUserLoginQuery
{
    public class LoginDTO
    {
            public UserDTO User { get; set; } = new();
            public string Token { get; set; } = string.Empty;

    }
}
