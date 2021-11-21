using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppDatabase
{
    /*******************************************************
     * class representing a sql SPROC
     * 
     * For documentation on class fields and methods
     * refer to ISqlMethod interface implementation
     * *****************************************************/
    internal class SqlSproc : ISqlMethod
    {        
        public string name { get; set; }

        public List<SQLParameter> parameters { get; set; }

        public static string queryVerb { get { return "exec"; } }
        
        // constructor
        public SqlSproc(string name, List<SQLParameter> parameters)
        {
            this.parameters = parameters;
            this.name = name;
        }
        public string createQuery()
        {
            return $"{ queryVerb } dbo.{ name } "
                   + $"{ string.Join(",", parameters.Select(x => x.name.ToString())) }";
        }
    }
}
