using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Comunity.Application.Features.PartnerType.Commands.CreatePartnerType;
using Nnovah.Comunity.Application.Features.TechnicalType.Commands.CreateTechnicalType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TechnicalTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<TechnicalTypeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TechnicalTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TechnicalTypeController>
        [HttpPost("CreateTechnicalType")]
        public async Task<ActionResult> Post(CreateTechnicalTypeCommand createTechnicalTypeCommand)
        {
            var response = await _mediator.Send(createTechnicalTypeCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<TechnicalTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TechnicalTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
