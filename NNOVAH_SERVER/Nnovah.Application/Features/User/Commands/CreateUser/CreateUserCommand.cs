using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand: IRequest<int>
    {
        public string Name { get; set; }
        public int Usertype { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IdPartner { get; set; }
        public int State { get; set; }
    }
}
