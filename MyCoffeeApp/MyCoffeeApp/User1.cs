using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace MyCoffeeApp
{
    public class User1
    {
        [PrimaryKey, AutoIncrement]
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
