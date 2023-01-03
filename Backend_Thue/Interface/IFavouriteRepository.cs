using Backend_Thue.Data;
using Backend_Thue.Models;

namespace Backend_Thue.Interface;

public interface IFavouriteRepository
{
    Favourite? GetAllProductFromFavourite(Guid userId);
    bool AddProductToFavourite(AddProductToFavouriteModel addProductToFavourite);
    bool RemoveProductFromFavourite(Guid favouriteDetailId);
    bool CreateUserFavourite(Guid userId);
}