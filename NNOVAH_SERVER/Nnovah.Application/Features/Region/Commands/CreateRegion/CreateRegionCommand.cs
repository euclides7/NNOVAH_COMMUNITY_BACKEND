﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Region.Commands.CreateRegion
{
    public class CreateRegionCommand:IRequest<int>
    {
        public int Description { get; set; }
    }
}
