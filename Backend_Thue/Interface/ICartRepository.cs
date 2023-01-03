using Backend_Thue.Data;
using Backend_Thue.Models;

namespace Backend_Thue.Interface;

public interface ICartRepository
{
    public Cart? GetCartByUserId(Guid userId);
    public bool AddProductToCart(AddProductToCartModel addProductToCartModel);
    public bool RemoveProductFromCart(Guid cartDetailId);
    public bool CreateUserCart(Guid userId);
}