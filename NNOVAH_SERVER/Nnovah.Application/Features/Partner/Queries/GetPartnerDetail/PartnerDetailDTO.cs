using Nnovah.Application.Features.Partner.Queries.GetPartner;
using Nnovah.Comunity.Application.Features.Address.Queries.GetAddress;
using Nnovah.Comunity.Application.Features.Contacts.Queries.GetContacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Partner.Queries.GetPartnerDetail
{
    public class PartnerDetailDTO
    {
        public string EncryptedId { get; set; }
        public string Name { get; set; }
        public string Nif { get; set; }
        public AddressDTO Address { get; set; }
        public ContactsDTO Contact { get; set; }
        public int PartnerType { get; set; }
    }
}
