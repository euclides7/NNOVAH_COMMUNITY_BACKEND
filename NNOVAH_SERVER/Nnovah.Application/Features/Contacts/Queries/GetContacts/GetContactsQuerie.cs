using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Contacts.Queries.GetContacts
{
    public class GetContactsQuerie : IRequest<List<ContactsDTO>>
    {
    }
}
