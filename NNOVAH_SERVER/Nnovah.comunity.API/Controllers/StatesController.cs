using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Comunity.Application.Features.PartnerType.Commands.CreatePartnerType;
using Nnovah.Comunity.Application.Features.States.Commands.CreateStates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatesController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<StatesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StatesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatesController>
        [HttpPost("CreateStates")]
        public async Task<ActionResult> Post(CreateStatesCommand createStatesCommand)
        {
            var response = await _mediator.Send(createStatesCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<StatesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
