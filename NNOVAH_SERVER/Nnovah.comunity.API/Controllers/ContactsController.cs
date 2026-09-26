using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Comunity.Application.Features.Address.Commands.CreateAddress;
using Nnovah.Comunity.Application.Features.Address.Commands.UpdateAddress;
using Nnovah.Comunity.Application.Features.Address.Queries.GetAddress;
using Nnovah.Comunity.Application.Features.Contacts.Commands.CreateContacts;
using Nnovah.Comunity.Application.Features.Contacts.Commands.UpdateContacts;
using Nnovah.Comunity.Application.Features.Contacts.Queries.GetContacts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<List<ContactsDTO>> Get()
        {
            var contacts = await _mediator.Send(new GetContactsQuerie());
            return contacts;
        }
 
        [HttpPost("CreateContacts")]
        public async Task<ActionResult> Post(CreateContactsCommand createContactsCommand)
        {
            var response = await _mediator.Send(createContactsCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<ContactsController>/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateContactsCommand command)
        {
              command.Id= id;
            await _mediator.Send(command);
            return NoContent();
        }
        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
