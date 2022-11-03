using SQLite;

namespace MyCoffeeApp.Shared.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string username { get; set; }
    }
}
