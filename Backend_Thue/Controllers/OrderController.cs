using Backend_Thue.Interface;
using Backend_Thue.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Thue.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController: ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    [HttpGet("orders/{userId:guid}")]
    public IActionResult GetOrdersByUserId(Guid userId)
    {
        try
        {
            var orders = _orderRepository.GetAllOrders(userId);
            return Ok(orders);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }   
    
    [HttpGet("order/{orderId:guid}")]
    public IActionResult GetOrderById(Guid orderId)
    {
        try
        {
            var order = _orderRepository.GetOrderById(orderId);

            return order == null ? StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy đơn hàng này") : Ok(order);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpPost("order")]
    public IActionResult CreateOrder([FromBody] CreateOrderModel createOrderModel)
    {
        try
        {
            var order = _orderRepository.CreateOrder(createOrderModel);

            return order == null ? StatusCode(StatusCodes.Status400BadRequest, "Giỏ hàng không tìm thấy hoặc không có sản phẩm nào") : Ok(order);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}