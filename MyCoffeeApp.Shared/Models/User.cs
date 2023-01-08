using SQLite;
using System;
using System.Collections.Generic;

namespace MyCoffeeApp.Shared.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Favorite favourite { get; set; }
        public Cart cart { get; set; }
        public List<Orders> orders { get; set; }

    }
}
