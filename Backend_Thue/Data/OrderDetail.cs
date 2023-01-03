using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend_Thue.Data;

public class OrderDetail
{
    [Key]
    public Guid ID { get; set; }
    
    [Required(ErrorMessage = "Phải có số lượng")]
    public int Quantity { get; set; }
    
    [Required(ErrorMessage = "Order id phải có")]
    public Guid OrderId { get; set; }
    [ForeignKey("OrderId")]
    [JsonIgnore]
    public virtual Order Order { get; set; }
    
    [Required(ErrorMessage = "Coffee ID phải có")]
    [JsonIgnore]
    public Guid CoffeeId { get; set; }
    [ForeignKey("CoffeeId")]
    public virtual Coffee Coffee { get; set; }
}