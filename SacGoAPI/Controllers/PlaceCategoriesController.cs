using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SacGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceCategoriesController : ControllerBase
    {
        // dependency injection to use sql connection
        private IConfiguration _configuration;

        public PlaceCategoriesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET
        // returns place categories
        [HttpGet]
        public JsonResult Get(string id)
        {
            DataTable dt = new DataTable(); 

            // sql instance
            string sqlDataSrc = _configuration.GetConnectionString(AppConstants.AppConnectionString);

            // define reader and execute sql query
            SqlDataReader dataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSrc))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = "select * from dbo.VIEW_PLACE_CATEGORIES(@id)"; //The name of the other stored procedure.  
                    cmd.Parameters.Add("@id", SqlDbType.BigInt);
                    cmd.Parameters["@id"].Value = id ?? (object)DBNull.Value;
                    dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }

                // close connections
                dataReader.Close();
                sqlConnection.Close();

                // return results
                return new JsonResult(dt);
            }


        }
    }
}
