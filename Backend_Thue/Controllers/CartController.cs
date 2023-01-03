using Backend_Thue.Interface;
using Backend_Thue.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Thue.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController: ControllerBase
{
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
    
    [HttpGet("{userId:guid}")]
    public IActionResult GetAllProducts(Guid userId) {
        try
        {
            var cart = _cartRepository.GetCartByUserId(userId);

            if (cart == null)
            {
                return NotFound("Không tìm thấy giỏ hàng");
            }

            return Ok(cart);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpPost("")]
    public IActionResult AddProductToCart([FromBody] AddProductToCartModel addProductToCartModel)
    {
        try
        {
            var checkedProduct = _cartRepository.AddProductToCart(addProductToCartModel);

            return !checkedProduct ? StatusCode(StatusCodes.Status400BadRequest, "Không thể thêm sản phẩm vào giỏ hàng") : Ok("Thêm thành công");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost("{userId:guid}")]
    public IActionResult CreateUserCart(Guid userId)
    {
        try
        {
            var checkedCreateCart = _cartRepository.CreateUserCart(userId);

            if (!checkedCreateCart)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Đã tạo giỏ hàng cho người dùng này");
            }

            return Ok("Tạo thành công");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("{cartDetailId}")]
    public IActionResult RemoveProductFromCart(Guid cartDetailId)
    {
        try
        {
            var checkedDeleteProduct = _cartRepository.RemoveProductFromCart(cartDetailId);

            return !checkedDeleteProduct ? StatusCode(StatusCodes.Status400BadRequest, "Không thể xóa sản phẩm này") : Ok("Xóa thành công");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}