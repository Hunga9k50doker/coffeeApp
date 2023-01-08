using SQLite;

namespace MyCoffeeApp.Shared.Models
{
    public class Coffee
    {
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public string detail { get; set; }
        public float price { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }
}
