using MediatR;


namespace Nnovah.Comunity.Application.Features.Contacts.Commands.UpdateContacts
{
    public record UpdateContactsCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Email1 { get; set; }
    }
}
