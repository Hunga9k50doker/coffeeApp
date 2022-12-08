using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyCoffeeApp.Shared.Models
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Detail { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
