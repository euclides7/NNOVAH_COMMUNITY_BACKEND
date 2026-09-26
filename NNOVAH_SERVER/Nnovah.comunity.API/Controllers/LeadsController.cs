using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Comunity.Application.Features.Leads.Commands.CreateLeads;
using Nnovah.Comunity.Application.Features.PartnerType.Commands.CreatePartnerType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeadsController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<LeadsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LeadsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LeadsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LeadsController>/5
        [HttpPost("CreateLeads")]
        public async Task<ActionResult> Post(CreateLeadsCommand createLeadsCommand)
        {
            var response = await _mediator.Send(createLeadsCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // DELETE api/<LeadsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
