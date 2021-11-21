using System;
using System.Collections.Generic;
using System.Text;

namespace AppDatabase
{
    public interface ISqlMethod
    {
        public List<SQLParameter> parameters { get; set; } // function parameters i.e "@name"
        public string name { get; set; } // name of function i.e "ADD_NEW_ENTITY"
        public static string queryVerb { get; } // verb of query i.e "select * from", "exec"
        public string createQuery(); // create  query from parameters i.e "select * from dbo.ADD_NEW_ENTITY(@name)"
    }
}
