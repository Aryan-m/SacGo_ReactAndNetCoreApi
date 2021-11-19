using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacGoAPI.Models
{
    public class Place : Entity
    {
        public string address { get; set; }
        public string notes { get; set; }
        public string imageFile { get; set; }
        public int PlaceCategory { get; set; }
    }
}
