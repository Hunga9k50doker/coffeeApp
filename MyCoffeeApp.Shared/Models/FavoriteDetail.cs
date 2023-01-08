using SQLite;

namespace MyCoffeeApp.Shared.Models
{
    public class favouriteDetails
    {
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public Coffee coffee { get; set; }

    }
}
