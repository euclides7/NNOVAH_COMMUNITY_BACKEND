using AutoMapper;
using Nnovah.Comunity.Application.Features.Contacts.Commands.CreateContacts;
using Nnovah.Comunity.Domain;


namespace Nnovah.Comunity.Application.MappingProfile
{
    public class ContactsProfile:Profile
    {
        public ContactsProfile()
        {
            CreateMap<CreateContactsCommand,Contacts>().ReverseMap();
        }
    }
}
