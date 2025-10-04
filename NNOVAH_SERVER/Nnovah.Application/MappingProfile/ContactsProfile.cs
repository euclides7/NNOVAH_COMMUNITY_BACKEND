using AutoMapper;
using Nnovah.Comunity.Application.Features.Contacts.Commands.CreateContacts;
using Nnovah.Comunity.Application.Features.Contacts.Commands.UpdateContacts;
using Nnovah.Comunity.Application.Features.Contacts.Queries.GetContacts;
using Nnovah.Comunity.Domain;


namespace Nnovah.Comunity.Application.MappingProfile
{
    public class ContactsProfile:Profile
    {
        public ContactsProfile()
        {
            CreateMap<CreateContactsCommand,Contacts>().ReverseMap();
            CreateMap<UpdateContactsCommand,Contacts>().ReverseMap();
            CreateMap<ContactsDTO,Contacts>().ReverseMap();
        }
    }
}
