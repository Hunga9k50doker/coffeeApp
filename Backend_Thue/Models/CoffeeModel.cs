using System.ComponentModel.DataAnnotations;

namespace Backend_Thue.Models;

public class AddCoffeeModel
{
    [Required(ErrorMessage = "Tên phải có")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Mô tả sản phẩm phải có")]
    public string Detail { get; set; }
    
    [Required(ErrorMessage = "Giá cả phải có")]
    public long Price { get; set; }
    
    [Required(ErrorMessage = "Ảnh phải có")]
    public string Image { get; set; }
}

public class EditCoffeeModel : AddCoffeeModel
{
    
}