using System.ComponentModel.DataAnnotations;

namespace Backend_Thue.Models;

public class AddProductToFavouriteModel
{

    [Required]
    public Guid CoffeeId { get; set; }
    
    [Required]
    public Guid FavouriteId { get; set; }
}