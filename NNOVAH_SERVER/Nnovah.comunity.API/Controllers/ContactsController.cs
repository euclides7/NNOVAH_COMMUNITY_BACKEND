using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Comunity.Application.Features.Address.Commands.CreateAddress;
using Nnovah.Comunity.Application.Features.Contacts.Commands.CreateContacts;

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
        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactsController>
        [HttpPost("Contacts")]
        public async Task<ActionResult> Post(CreateContactsCommand createContactsCommand)
        {
            var response = await _mediator.Send(createContactsCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
