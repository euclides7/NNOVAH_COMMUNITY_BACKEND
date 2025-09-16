using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.UserType.Commands.CreateUserType
{
    public class CreateUserTypeCommand:IRequest<int>
    {
        public string Description { get; set; }
    }
}
