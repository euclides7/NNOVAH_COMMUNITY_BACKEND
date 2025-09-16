using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.TechnicalType.Commands.CreateTechnicalType
{
    public class CreateTechnicalTypeCommand:IRequest<int>
    {
        public string Description { get; set; }
    }
}
