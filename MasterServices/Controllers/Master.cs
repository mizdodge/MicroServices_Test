using MasterServices.Model;
using MyProjectBE.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterServices.Data;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MasterServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Master : ControllerBase
    {
        public IConfiguration Configuration;
        public ApplicationDbContext AppDbContext { get; set; }

        public Master(IConfiguration configuration, ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            Configuration = configuration;
        }
        // GET: api/<Master>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Master>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            List<UserModel> user = AppDbContext.User.Where(x=>x.UserID == Convert.ToInt64(id)).ToList();
            
            return Ok(new { RESULT = "OK", user });
        }

        // POST api/<Master>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Master>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Master>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("GetListItems")]
        public IActionResult GetAllListItems()
        {
            List<UserModel> user = AppDbContext.User.ToList();
            
            return Ok(new { RESULT = "OK", user });
        }
    }
}
