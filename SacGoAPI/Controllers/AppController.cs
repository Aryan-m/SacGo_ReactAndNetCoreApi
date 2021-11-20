using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SacGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AppController : ControllerBase
    {
        private IConfiguration _configuration;
        public AppController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public JsonResult Get(string udfName, List<SQLParameter> parameters)
        {
            SQLHandler sqlHandler = new SQLHandler(_configuration, AppConstants.AppConnectionString);
            return sqlHandler.callUDF(udfName, parameters);

        }
    }
}
