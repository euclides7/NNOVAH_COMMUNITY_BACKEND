using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Comunity.Application.Features.Customer.Commands.CreateCustomer;
using Nnovah.Comunity.Application.Features.Partner.Commands.CreatePartner;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PartnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
