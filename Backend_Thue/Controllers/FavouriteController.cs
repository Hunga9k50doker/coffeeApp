using Backend_Thue.Interface;
using Backend_Thue.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Thue.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavouriteController: ControllerBase
{
    private readonly IFavouriteRepository _favouriteRepository;

    public FavouriteController(IFavouriteRepository favouriteRepository)
    {
        _favouriteRepository = favouriteRepository;
    }

    [HttpGet("{userId:guid}")]
    public IActionResult GetAllCoffeesFromFavourite(Guid userId)
    {
        try
        {
            var favourite = _favouriteRepository.GetAllProductFromFavourite(userId);
            
            if(favourite == null)
            {
                return NotFound("Không tìm thấy yêu thích của người dùng này");
            }

            return Ok(favourite);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost("")]
    public IActionResult AddProductToFavourite(AddProductToFavouriteModel addProductToFavouriteModel)
    {
        try
        {
            var checkedProduct = _favouriteRepository.AddProductToFavourite(addProductToFavouriteModel);

            if (!checkedProduct)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Sản phẩm đã có trong yêu thích");
            }

            return Ok("Thêm thành công");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost("{userId:guid}")]
    public IActionResult CreateUserFavourite(Guid userId)
    {
        try
        {
            var checkedCreateFavourite = _favouriteRepository.CreateUserFavourite(userId);

            if (!checkedCreateFavourite)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Đã tạo yêu thích cho người dùng này");
            }

            return Ok("Tạo yêu thích thành công");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("{favouriteDetailId:guid}")]
    public IActionResult RemoveProductFromFavourite(Guid favouriteDetailId)
    {
        try
        {
            var checkedProduct = _favouriteRepository.RemoveProductFromFavourite(favouriteDetailId);

            return !checkedProduct ? StatusCode(StatusCodes.Status400BadRequest, "Không tìm thấy sản phẩm để xóa") : Ok("Xóa thành công");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}