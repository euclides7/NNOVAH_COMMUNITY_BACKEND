using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Comunity.Application.Features.Address.Commands.CreateAddress;
using Nnovah.Comunity.Application.Features.Address.Commands.UpdateAddress;
using Nnovah.Comunity.Application.Features.Address.Queries.GetAddress;
using Nnovah.Comunity.Application.Features.Contacts.Commands.UpdateContacts;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomer;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerQuery;
using Nnovah.Comunity.Application.Features.User.Commands.CreateUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            this._mediator = mediator;
        }
    
        [HttpGet]
        public async Task<List<AddressDTO>> Get()
        {
            var address = await _mediator.Send(new GetAddressQuerie());
            return address;
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddressController>
 
        [HttpPost("CreateAddress")]
        public async Task<ActionResult> Post(CreateAddressComand createAddressComand)
        {
            var response = await _mediator.Send(createAddressComand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateAddressCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }
        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
