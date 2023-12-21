using MasterServices.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterServices.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MasterServices.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration Configuration;
        public ApplicationDbContext AppDbContext { get; set; }

        public LoginController(IConfiguration configuration, ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            Configuration = configuration;
        }
        // GET: auth/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "OK" };
        }

        // GET auth/<LoginController>/5
        //[HttpPost("{username}")]
        //public IActionResult Get(string username, string password)
        //{
            
        //}
        // POST auth/<LoginController>
        [HttpPost]
        public IActionResult Post(UserModel userData)
        {
            var getData = (from x in AppDbContext.UserMaster where x.Username == userData.Username && x.Password == userData.Password select x).FirstOrDefault();
            getData.Password = "";
            if (getData != null)
            {
                return Ok(new { status = "200", data = getData });
            }
            else
            {
                return Ok(new { status = "401", data = new { } });
            }
        }

        // PUT auth/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE auth/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
