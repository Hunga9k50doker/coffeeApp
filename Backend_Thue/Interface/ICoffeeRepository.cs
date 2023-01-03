using Backend_Thue.Data;
using Backend_Thue.Models;

namespace Backend_Thue.Interface;

public interface ICoffeeRepository
{
    Coffee AddCoffee(AddCoffeeModel addCoffeeModel);
    List<Coffee> GetAllCoffee();
    Coffee? GetCoffeeById(Guid coffeeId);
    Coffee? EditCoffee(Guid coffeeId, EditCoffeeModel editCoffeeModel);
    bool DeleteCoffee(Guid coffeeId);
}