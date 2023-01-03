using Backend_Thue.Data;
using Backend_Thue.Interface;
using Backend_Thue.Models;

namespace Backend_Thue.Services;

public class OrderService: IOrderRepository
{
    private readonly MyDbContext _context;
    
    public OrderService(MyDbContext context)
    {
        _context = context;
    }
    
    public List<Order> GetAllOrders(Guid userId)
    {
        return _context.Orders.Where(order => order.UserId == userId).ToList();
    }

    public Order? GetOrderById(Guid orderId)
    {
        var order = _context.Orders.FirstOrDefault(order => order.ID == orderId);

        return order;
    }

    public Order? CreateOrder(CreateOrderModel createOrderModel)
    {
        var cart = _context.Carts.FirstOrDefault(cart => cart.UserId == createOrderModel.UserId);

        if (cart is null or { CartDetails.Count: 0 })
        {
            return null;
        }
        
        var order = new Order
        {
            ID = Guid.NewGuid(),
            UserId = createOrderModel.UserId,
            Name = createOrderModel.Name,
            OrderDate = DateTime.Now,
            Email = createOrderModel.Email,
            Address = createOrderModel.Address,
            PhoneNumber = createOrderModel.PhoneNumber,
            OrderDetails = cart.CartDetails.Select(cartDetail => new OrderDetail
            {
                ID = Guid.NewGuid(),
                OrderId = cartDetail.CartId,
                CoffeeId = cartDetail.CoffeeId,
                Quantity = cartDetail.Quantity,
            }).ToList()
        };
        
        _context.CartDetails.RemoveRange(cart.CartDetails);
        
        _context.Orders.Add(order);
        _context.SaveChanges();
        
        return order;
    }
}