using SQLite;

namespace MyCoffeeApp.Shared.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}
