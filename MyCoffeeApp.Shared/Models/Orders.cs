using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyCoffeeApp.Shared.Models
{
    public class Orders
    {
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string orderDate { get; set; }
        public string userId { get; set; }
        public User user { get; set; }

        public List<orderDetails> orderDetails { get; set; }
    }
}
