using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.States.Commands.CreateStates
{
    public class CreateStatesCommand:IRequest<int>
    {
        public string Description { get; set; }
        public bool LicenseState { get; set; }
        public bool LicenceOrderState { get; set; }
        public bool LeadState { get; set; }
    }
}
