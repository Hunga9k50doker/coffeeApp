using Backend_Thue.Data;
using Backend_Thue.Interface;
using Backend_Thue.Models;

namespace Backend_Thue.Services;

public class FavouriteService: IFavouriteRepository
{
    private readonly MyDbContext _context;

    public FavouriteService(MyDbContext context)
    {
        _context = context;
    }
    public bool AddProductToFavourite(AddProductToFavouriteModel addProductToFavourite)
    {
        var favouriteDetail = _context.FavouriteDetails.SingleOrDefault(favouriteDetail =>
            favouriteDetail.FavouriteId == addProductToFavourite.FavouriteId &&
            favouriteDetail.CoffeeId == addProductToFavourite.CoffeeId);

        if (favouriteDetail != null)
        {
            return false;
        }
        
        favouriteDetail = new FavouriteDetail
        {
            CoffeeId = addProductToFavourite.CoffeeId,
            FavouriteId = addProductToFavourite.FavouriteId
        };

        _context.FavouriteDetails.Add(favouriteDetail);

        _context.SaveChanges();

        return true;
    }

    public bool RemoveProductFromFavourite(Guid favouriteDetailId)
    {
        var favouriteDetail =
            _context.FavouriteDetails.SingleOrDefault(favouriteDetail => favouriteDetail.ID == favouriteDetailId);

        if (favouriteDetail == null)
        {
            return false;
        }

        _context.FavouriteDetails.Remove(favouriteDetail);

        _context.SaveChanges();

        return true;
    }

    public bool CreateUserFavourite(Guid userId)
    {
        var favourite = _context.Favourites.SingleOrDefault(favourite => favourite.UserId == userId);

        if (favourite != null)
        {
            return false;
        }

        favourite = new Favourite
        {
            UserId = userId
        };

        _context.Favourites.Add(favourite);

        _context.SaveChanges();

        return true;
    }

    public Favourite? GetAllProductFromFavourite(Guid userId)
    {
        var favourite = _context.Favourites.SingleOrDefault(favourite => favourite.UserId == userId);

        return favourite;
    }
}