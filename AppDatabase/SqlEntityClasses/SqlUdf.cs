using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppDatabase
{
    /*******************************************************
     * class representing a sql UDF
     * 
     * For documentation on class fields and methods
     * refer to ISqlMethod interface implementation
     * *****************************************************/
    internal class SqlUdf : ISqlMethod
    {
        public string name { get; set; }

        public List<SQLParameter> parameters { get; set; }

        // constructor
        public SqlUdf(string name, List<SQLParameter> parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }

        public static string queryVerb { get { return "select * from"; } }

        public string createQuery()
        {
            return $"{ queryVerb } dbo.{ name } ( "
                   + $"{ string.Join(",", parameters.Select(x => x.name.ToString())) } )";
        }
    }
}
