using Backend_Thue.Data;
using Backend_Thue.Interface;
using Backend_Thue.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Thue.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoffeeController: ControllerBase
{
    private readonly ICoffeeRepository _coffeeRepository;

    public CoffeeController(ICoffeeRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }

    [HttpGet("")]
    public IActionResult GetAllCoffee()
    {
        try
        {
            var coffees = _coffeeRepository.GetAllCoffee();

            return Ok(coffees);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("{coffeeId}")]
    public IActionResult GetCoffeeById(Guid coffeeId)
    {
        try
        {
            var coffee = _coffeeRepository.GetCoffeeById(coffeeId);

            return coffee == null ? StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy coffee này") : Ok(coffee);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost("")]
    public IActionResult AddCoffee([FromBody] AddCoffeeModel addCoffeeModel)
    {
        try
        {
            var coffee = _coffeeRepository.AddCoffee(addCoffeeModel);

            return Ok(coffee);
        }
        catch (Exception e)
        {            
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPut("{coffeeId}")]
    public IActionResult UpdateCoffeeById(Guid coffeeId, [FromBody] EditCoffeeModel editCoffeeModel)
    {
        try
        {
            var coffee = _coffeeRepository.EditCoffee(coffeeId, editCoffeeModel);

            if (coffee == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy coffee này");
            }

            return Ok(coffee);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("{coffeeId:guid}")]
    public IActionResult DeleteCoffeeById(Guid coffeeId)
    {
        try
        {
            var deletedCoffee = _coffeeRepository.DeleteCoffee(coffeeId);

            return !deletedCoffee ? StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy coffee này") : Ok("Xóa thành công");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}