using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AppDatabase
{
    /*******************************************************
     * Handles sql calls to sprocs, UDFs, etc
     * *****************************************************/
    public class SQLHandler
    {
        // dependency injection to use sql connection
        private IConfiguration _configuration;
        private string connectionString;

        public SQLHandler(IConfiguration configuration, string connectionString)
        {
            _configuration = configuration;
            this.connectionString = connectionString;
        }

        public JsonResult callUDF(string udfName, List<SQLParameter> parameters) {  
            DataTable dt = new DataTable(); 

            // sql instance
            string sqlDataSrc = _configuration.GetConnectionString(connectionString);

            // define reader and execute sql query
            SqlDataReader dataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSrc))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    // set UDF info
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = $"select * from dbo.{ udfName } ( "
                                    + $"{ string.Join(",", parameters.Select(x => x.ParameterName.ToString())) } )";

                    // add parameters
                    foreach (SQLParameter param in parameters)
                    {
                        cmd.Parameters.Add(param.ParameterName, param.SqlDbType).Value = param.Value ?? (object)DBNull.Value;
                    }

                    // execute query
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
