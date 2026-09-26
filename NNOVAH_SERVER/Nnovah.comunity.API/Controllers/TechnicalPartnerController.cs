using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Comunity.Application.Features.States.Commands.CreateStates;
using Nnovah.Comunity.Application.Features.TechnicalPartner.Commands.CreateTechnicalPartner;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalPartnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TechnicalPartnerController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<TechnicalPartnerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TechnicalPartnerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TechnicalPartnerController>
        [HttpPost("CreateTechnicalPartner")]
        public async Task<ActionResult> Post(CreateTechnicalPartnerCommand createTechnicalPartnerCommand)
        {
            var response = await _mediator.Send(createTechnicalPartnerCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }


        // PUT api/<TechnicalPartnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TechnicalPartnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
