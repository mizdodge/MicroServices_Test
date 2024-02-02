using MasterServices.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterServices.Model;
using MyProjectBE.Model;
using WebApplication1.Models;

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
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var getData = (from x in AppDbContext.UserMaster where x.Username == username select x).FirstOrDefault();

            if (getData != null)
            {
                return Ok(new { status = "500", message = "Username already exist" });
            }
            else
            {
                return Ok(new { status = "200", message = "OK" });
            }
        }
        [HttpPost]
        public IActionResult Post(UserMasterModel userData)
        {
            ResultModel res_ = new ResultModel();
            try
            {
                var getData = (from x in AppDbContext.UserMaster where x.Username == userData.Username && x.Password == userData.Password select x).FirstOrDefault();
                if (getData != null)
                {
                    getData.Password = "";
                    getData.UserDetail = (from x in AppDbContext.UserDetailMaster where x.ID == getData.UserDetailID select x).FirstOrDefault();
                    res_.status = "200";
                    res_.message = "OK";
                    res_.data = getData;
                    return Ok(res_);
                }
                else
                {
                    res_.status = "401";
                    res_.message = "User Does not exist / Password Wrong";
                    res_.data = null;
                    return Ok(res_);
                }
            }
            catch (Exception ex)
            {
                res_.status = "401";
                res_.message = "Error : "+ex.Message.ToString();
                res_.data = null;
                return Ok(res_);
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
