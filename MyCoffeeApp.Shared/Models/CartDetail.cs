using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyCoffeeApp.Shared.Models
{
    public class cartDetails
    {
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public int quantity { get; set; }
        public Coffee coffee { get; set; }
       
    }
}
