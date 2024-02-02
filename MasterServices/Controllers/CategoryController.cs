using MasterServices.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyProjectBE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MasterServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public IConfiguration Configuration;
        public ApplicationDbContext AppDbContext { get; set; }

        public CategoryController(IConfiguration configuration, ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            Configuration = configuration;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            var res_ = AppDbContext.Category.ToList();
            return Ok(res_);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{CategoryID}")]
        public IActionResult Get(int CategoryID)
        {
            var res_ = AppDbContext.Category.Where(x => x.CategoryID == CategoryID).ToList();
            return Ok(res_);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post(CategoryModel data)
        {
            ResultModel res_ = new ResultModel();
            try
            {
                AppDbContext.Category.Add(data);
                AppDbContext.SaveChanges();
                res_.status = "200";
                res_.message = "OK";
            }
            catch (Exception ex)
            {
                res_.status = "500";
                res_.message = ex.Message.ToString();
            }
                        
            return Ok(res_);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{CategoryID}")]
        public IActionResult Put(int CategoryID, CategoryModel data)
        {
            ResultModel res_ = new ResultModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration["ConnectionStrings:Server"]))
                {
                    //var data = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoryModel>(value);
                    using (SqlCommand cmds = new SqlCommand(@" update Category set CategoryName ='" + data.CategoryName + "' where CategoryID = '" + CategoryID.ToString() + "'", conn))
                    {
                        conn.Open();
                        var callbackExecuteData = cmds.ExecuteScalar();
                        conn.Close();
                    }

                    res_.status = "200";
                    res_.message = "OK";
                }
            }
            catch (Exception ex)
            {
                res_.status = "500";
                res_.message = ex.Message;
            }
            return Ok();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{CategoryID}")]
        public IActionResult Delete(int CategoryID)
        {
            ResultModel res_ = new ResultModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration["ConnectionStrings:Server"]))
                {
                    //var data = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoryModel>(value);
                    using (SqlCommand cmds = new SqlCommand(@" delete Category where CategoryID = '" + CategoryID.ToString() + "'", conn))
                    {
                        conn.Open();
                        var callbackExecuteData = cmds.ExecuteScalar();
                        conn.Close();
                    }

                    res_.status = "200";
                    res_.message = "OK";
                }
            }
            catch (Exception ex)
            {
                res_.status = "500";
                res_.message = ex.Message;
            }
            return Ok(res_);
        }
    }
}
