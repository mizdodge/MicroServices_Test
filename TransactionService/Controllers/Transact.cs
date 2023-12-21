using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransactionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Transact : ControllerBase
    {
        // GET: api/<Transact>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Transact>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Transact>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Transact>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Transact>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("AddToCart/{dataset}")]
        public IActionResult AddToCart(string dataset)
        {
            return Ok(new { testing = "1", testing2 = "2" });
        }
    }
}
