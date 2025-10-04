using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Application.Features.Partner.Queries.GetPartner;
using Nnovah.Comunity.Application.Features.Address.Commands.UpdateAddress;
using Nnovah.Comunity.Application.Features.Address.Queries.GetAddress;
using Nnovah.Comunity.Application.Features.Customer.Commands.CreateCustomer;
using Nnovah.Comunity.Application.Features.Customer.Commands.DeleteCustomer;
using Nnovah.Comunity.Application.Features.Partner.Commands.CreatePartner;
using Nnovah.Comunity.Application.Features.Partner.Commands.DeletePartner;
using Nnovah.Comunity.Application.Features.Partner.Commands.UpdatePartner;
using Nnovah.Comunity.Application.Features.Partner.Queries.GetPartner;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartnerController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<PartnerController>
        [HttpGet]
        public async Task<List<PartnerDTO>> Get()
        {
            return await this._mediator.Send(new GetPartnerQuerie());
        }

        // GET api/<PartnerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PartnerController>
        [HttpPost("CreatePartner")]
        public async Task<ActionResult> Post(CreatePartnerCommand createPartnerCommand)
        {
            var response = await _mediator.Send(createPartnerCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }


        // PUT api/<PartnerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePartnerCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }
        // DELETE api/<PartnerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePartnerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
