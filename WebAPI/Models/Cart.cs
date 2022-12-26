using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Cart
    {
        public int id { get; set; }
        public int id_user { get; set; }
        public string address { get; set; }
        public List<Coffee> coffees { get; set; }
    }
}