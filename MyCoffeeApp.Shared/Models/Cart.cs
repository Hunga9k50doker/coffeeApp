﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyCoffeeApp.Shared.Models
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public int quantity { get; set; }
        public string coffeeId { get; set; }
        public string cartId { get; set; }
        public User user { get; set; }
        public List<cartDetails> cartDetails { get; set; }
        
    }
}
