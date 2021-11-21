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

        /****************************************************************************
         * sets up proper SqlClient parameters and calls a table valued SQL UDF
         * **************************************************************************/
        public DataTable execSqlFunction(ISqlMethod sqlMethod)
        {
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
                    cmd.CommandText = sqlMethod.createQuery();

                    // add parameters
                    foreach (SQLParameter param in sqlMethod.parameters)
                    {
                        cmd.Parameters.Add(param.name, param.sqlDbType).Value = param.value ?? (object)DBNull.Value;
                    }

                    // execute query
                    dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }

                // close connections
                dataReader.Close();
                sqlConnection.Close();

                // return results
                return dt;
            }
        }

        /****************************************************************************
         * calls a table valued SQL UDF
         * **************************************************************************/
        public JsonResult callUDF(string udfName, List<SQLParameter> parameters) {                                      
            try
            {
                return new JsonResult(execSqlFunction(new SqlUdf(udfName, parameters)));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        /****************************************************************************
         * executes a SQL SPROC
         * **************************************************************************/
        public JsonResult execSPROC(string sprocName, List<SQLParameter> parameters) {
            try
            {
                execSqlFunction(new SqlSproc(sprocName, parameters));
                return new JsonResult("Success");
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}
