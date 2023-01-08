using SQLite;
using System.Collections.Generic;

namespace MyCoffeeApp.Shared.Models
{
    public class Favorite
    {
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public List<favouriteDetails> favouriteDetails { get; set; }
        public User user { get; set; }
        public string userid { get; set; }
        public string coffeeId { get; set; }
        public string favouriteId { get; set; }

    }
}
