using Backend_Thue.Data;
using Backend_Thue.Models;

namespace Backend_Thue.Interface;

public interface IOrderRepository
{
    List<Order> GetAllOrders(Guid userId);
    Order? GetOrderById(Guid orderId);
    Order? CreateOrder(CreateOrderModel createOrderModel);
}