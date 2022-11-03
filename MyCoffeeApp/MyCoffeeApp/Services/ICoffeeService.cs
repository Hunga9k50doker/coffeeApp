using MyCoffeeApp.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCoffeeApp.Services
{
    public interface ICoffeeService
    {
        Task AddCoffee(string name, string detail, float price);
        Task<IEnumerable<Coffee>> GetCoffee();
        Task<Coffee> GetCoffee(int id);
        Task RemoveCoffee(int id);
    }
}