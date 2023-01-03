using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_Thue.Data;

public class Coffee
{
    [Key]
    public Guid ID { get; set; }
    
    [Required(ErrorMessage = "Tên phải có")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Mô tả sản phẩm phải có")]
    public string Detail { get; set; }
    
    [Required(ErrorMessage = "Giá cả phải có")]
    public long Price { get; set; }
    
    [Required(ErrorMessage = "Ảnh phải có")]
    public string Image { get; set; }

    [JsonIgnore]
    public virtual ICollection<CartDetail> CartDetails { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<FavouriteDetail> FavouriteDetails { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}