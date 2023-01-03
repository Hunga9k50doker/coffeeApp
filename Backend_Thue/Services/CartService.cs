using Backend_Thue.Data;
using Backend_Thue.Interface;
using Backend_Thue.Models;

namespace Backend_Thue.Services;

public class CartService: ICartRepository
{
    private readonly MyDbContext _context;

    public CartService(MyDbContext context)
    {
        _context = context;
    }
    public Cart? GetCartByUserId(Guid userId)
    {
        var cart = _context.Carts.SingleOrDefault(cart => cart.UserId == userId);

        return cart;
    }

    public bool AddProductToCart(AddProductToCartModel addProductToCartModel)
    {
        var cartDetail = _context.CartDetails.SingleOrDefault(cartDetail =>
            cartDetail.CartId == addProductToCartModel.CartId && cartDetail.CoffeeId == addProductToCartModel.CoffeeId);

        if (cartDetail == null)
        {
            cartDetail = new CartDetail
            {
                Quantity = addProductToCartModel.Quantity,
                CartId = addProductToCartModel.CartId,
                CoffeeId = addProductToCartModel.CoffeeId
            };

            _context.CartDetails.Add(cartDetail);
        }

        else
        {
            cartDetail.Quantity += addProductToCartModel.Quantity;
        }

        _context.SaveChanges();

        return true;
    }

    public bool RemoveProductFromCart(Guid cartDetailId)
    {
        var cartDetail = _context.CartDetails.SingleOrDefault(cartDetail => cartDetail.ID == cartDetailId);

        if (cartDetail == null)
        {
            return false;
        }

        _context.CartDetails.Remove(cartDetail);

        _context.SaveChanges();
        return true;
    }

    public bool CreateUserCart(Guid userId)
    {
        var cart = _context.Carts.SingleOrDefault(cart => cart.UserId == userId);

        if (cart != null)
        {
            return false;
        }

        cart = new Cart
        {
            UserId = userId
        };

        _context.Carts.Add(cart);
        _context.SaveChanges();

        return true;
    }
}