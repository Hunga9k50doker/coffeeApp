using Backend_Thue.Data;
using Backend_Thue.Interface;
using Backend_Thue.Models;

namespace Backend_Thue.Services;

public class CoffeeService: ICoffeeRepository
{
    private readonly MyDbContext _context;
    public CoffeeService(MyDbContext context)
    {
        _context = context;
    }
    public Coffee AddCoffee(AddCoffeeModel addCoffeeModel)
    {
        var coffee = new Coffee
        {
            Detail = addCoffeeModel.Detail,
            Name = addCoffeeModel.Name,
            Image = addCoffeeModel.Image,
            Price = addCoffeeModel.Price
        };

        _context.Coffees.Add(coffee);

        _context.SaveChanges();

        return coffee;
    }

    public Coffee? GetCoffeeById(Guid coffeeId)
    {
        var coffee = _context.Coffees.SingleOrDefault(coffee => coffee.ID == coffeeId);
        return coffee;
    }

    public List<Coffee> GetAllCoffee()
    {
        var coffees = _context.Coffees.ToList();

        return coffees;
    }

    public Coffee? EditCoffee(Guid coffeeId, EditCoffeeModel editCoffeeModel)
    {
        var coffee = _context.Coffees.SingleOrDefault(coffee => coffee.ID == coffeeId);

        if (coffee == null)
        {
            return null;
        }

        coffee.Detail = editCoffeeModel.Detail;
        coffee.Name = editCoffeeModel.Name;
        coffee.Image = editCoffeeModel.Image;
        coffee.Price = editCoffeeModel.Price;

        _context.SaveChanges();

        return coffee;
    }

    public bool DeleteCoffee(Guid coffeeId)
    {
        var coffee = _context.Coffees.SingleOrDefault(coffee => coffee.ID == coffeeId);
        if (coffee == null)
        {
            return false;
        }

        _context.Coffees.Remove(coffee);

        _context.SaveChanges();

        return true;
    }
}