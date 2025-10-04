using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Application.Features.User.Queries.GetUser;
using Nnovah.Comunity.Application.Contracts.Security;
using Nnovah.Comunity.Application.Features.Customer.Commands.CreateCustomer;
using Nnovah.Comunity.Application.Features.Customer.Commands.DeleteCustomer;
using Nnovah.Comunity.Application.Features.Customer.Commands.UpdateCustomer;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomer;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerDetail;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerQuery;
using Nnovah.Comunity.Application.Features.User.Commands.CreateUser;
using Nnovah.Comunity.Application.Features.User.Queries.GetUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdProtector _idProtector;
        public CustomerController(IMediator mediator, IIdProtector idProtector)
        {
            this._mediator = mediator;
            _idProtector = idProtector;
        }

        [HttpGet]
        public async Task<List<CustomerDTO>> Get()
        {
            var command = await _mediator.Send(new GetCustomerQuery());
            return command;
        }
        [HttpGet("{id}")]
        public async Task<List<CustomerDetailDTO>> Get(string id)
        {
            var encryptedId = _idProtector.Decrypt(id);
            var command = await _mediator.Send(new GetCustomerDetailQuery(encryptedId.ToString()));
            return command;
        }

        [HttpPost("CreateCustomer")]
        public async Task<ActionResult> Post(CreateCustomerCommand createCustomerCommand)
        {
            var response = await _mediator.Send(createCustomerCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{encryptedId}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<IActionResult> Put(string encryptedId, [FromBody] UpdateCustomerCommand command)
        {
            var id = _idProtector.Decrypt(encryptedId); // converte EncryptedId para Id interno
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
