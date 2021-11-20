using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacGoAPI.Models
{
    /***************************************************
     * Abstract class all of our entities will inherit
     * from
     * 
     * Has basic fields and methods all entities might
     * have
     * **************************************************/
    public abstract class Entity
    {
        public int id { get; set; }
        public string name { get; set; }

    }
}
