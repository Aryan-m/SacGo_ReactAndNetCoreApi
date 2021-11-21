using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using AppDatabase;
using SacGoAPI.Models;

namespace SacGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceCategoriesController : AppController
    {
        public PlaceCategoriesController(IConfiguration _configuration) : base(_configuration)
        {
        }

        // GET
        // returns place categories
        [HttpGet]
        public JsonResult Get(string id)
        {
            List<SQLParameter> parameters = new List<SQLParameter> {
                new SQLParameter("@id", (object)id, SqlDbType.BigInt)
            };

            // invoke base method GET from parent class
            return this.Get("VIEW_PLACE_CATEGORIES", parameters);
        }

        // POST
        // saves a place category
        [HttpPost]
        public JsonResult Post(PlaceCategory pc)
        {
            List<SQLParameter> parameters = new List<SQLParameter> {
                new SQLParameter("@name", (object)pc.name, SqlDbType.VarChar)
            };

            // invoke base method GET from parent class
            return this.Post("ADD_NEW_PLACE_CATEGORY", parameters);
        }
    }
}
