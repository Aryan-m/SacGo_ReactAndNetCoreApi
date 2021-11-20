using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AppDatabase
{
    /*************************************************************
     * A simplified version of System.Data.SqlClientSqlParameter
     * ***********************************************************/
    public class SQLParameter
    {
        public string ParameterName;
        public object Value;
        public SqlDbType SqlDbType;

        public SQLParameter(string parameterName, object value, SqlDbType sqlDbType)
        {
            ParameterName = parameterName;
            Value = value;
            SqlDbType = sqlDbType;
        }
    }
}
