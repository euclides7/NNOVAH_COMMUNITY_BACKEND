using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nnovah.Comunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalPartnerController : ControllerBase
    {
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
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
