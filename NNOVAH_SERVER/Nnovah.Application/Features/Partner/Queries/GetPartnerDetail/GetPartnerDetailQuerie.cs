﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Partner.Queries.GetPartnerDetail
{
    public record GetPartnerDetailQuerie(string encryptedId) : IRequest<List<PartnerDetailDTO>>
    {
    }
}
