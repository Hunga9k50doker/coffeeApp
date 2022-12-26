using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebAPI.Models
{
    public class Coffee
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public string detail { get; set; } 
        public int count { get; set; }
        public string type { get; set; }
    }
}