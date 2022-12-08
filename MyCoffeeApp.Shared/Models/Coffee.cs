using SQLite;

namespace MyCoffeeApp.Shared.Models
{
    public class Coffee
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Detail { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
