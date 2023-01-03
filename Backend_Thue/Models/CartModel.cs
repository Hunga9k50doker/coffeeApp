using System.ComponentModel.DataAnnotations;

namespace Backend_Thue.Models;

public class AddProductToCartModel
{
    [Required(ErrorMessage = "Số lượng phải có")]
    public int Quantity { get; set; }
    
    [Required]
    public Guid CoffeeId { get; set; }
    
    [Required]
    public Guid CartId { get; set; }
}