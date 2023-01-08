using SQLite;

namespace MyCoffeeApp.Shared.Models
{
    public class CoffeeTL
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string detail { get; set; }
        public float price { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }
}
