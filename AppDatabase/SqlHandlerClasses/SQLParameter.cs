using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AppDatabase
{
    /*************************************************************
     * A simplified version of System.Data.SqlClientSqlParameter
     * 
     * represents a SQL function parameter class
     * ***********************************************************/
    public class SQLParameter
    {
        public string name;
        public object value;
        public SqlDbType sqlDbType;

        public SQLParameter(string name, object value, SqlDbType sqlDbType)
        {
            this.name = name;
            this.value = value;
            this.sqlDbType = sqlDbType;
        }
    }
}
