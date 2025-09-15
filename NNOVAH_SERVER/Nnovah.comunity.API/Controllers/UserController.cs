using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Nnovah.Application.Features.User.Queries.GetUser;
using Nnovah.Comunity.Application.Features.User.Commands.CreateUser;
using Nnovah.Comunity.Application.Features.User.Queries.GetUser;
using Nnovah.Comunity.Application.Features.User.Queries.GetUserDetailsQuery;
using Nnovah.Comunity.Application.Features.User.Queries.GetUserLogin;
using System.IdentityModel.Tokens.Jwt;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserDTO>> Get()
        {
            var user = await _mediator.Send(new GetUserQuery());
            return user;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserDetailsDTO> Get(int id)
        {
            var userDetails= await _mediator.Send(new GetUserDetailsQuery(id)); 
            return userDetails;
        }
        [HttpGet("me")]
        [Authorize] // garante que só quem tem token válido acessa
        public IActionResult GetPartner()
        {
            // Pegar o token do header
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Extrair o idPartner do claim
            var idPartnerClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "idPartner");
            if (idPartnerClaim == null)
                return Unauthorized();

            var idPartner = idPartnerClaim.Value;

            // Aqui podes buscar info no BD usando o idPartner
            return Ok(new { IdPartner = idPartner });
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] GetUserLoginQuery request)
        {
            var result = await _mediator.Send(new GetUserLoginQuery(request.idPartner, request.userCode, request.password));

            if (result == null)
                return Unauthorized("Credenciais inválidas");

            return Ok(result); // aqui pode retornar DTO do user + token JWT
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult> Post(CreateUserCommand CreateUserCommand)
        {
            var response = await _mediator.Send(CreateUserCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }
    }
}
