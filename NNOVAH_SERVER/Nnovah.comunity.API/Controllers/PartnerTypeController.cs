﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Comunity.Application.Features.PartnerType.Commands.CreatePartnerType;
using Nnovah.Comunity.Application.Features.User.Commands.CreateUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartnerTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<PartnerTypeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PartnerTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PartnerTypeController>
        [HttpPost("CreatePartnerType")]
        public async Task<ActionResult> Post(CreatePartnerTypeCommand createPartnerTypeCommand)
        {
            var response = await _mediator.Send(createPartnerTypeCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<PartnerTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PartnerTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
