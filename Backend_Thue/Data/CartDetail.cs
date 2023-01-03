using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend_Thue.Data;

public class CartDetail
{
    [Key]
    public Guid ID { get; set; }
    
    [Required(ErrorMessage = "Số lượng phải có")]
    public int Quantity { get; set; }
    
    [Required]
    [JsonIgnore]
    public Guid CoffeeId { get; set; }
    [ForeignKey("CoffeeId")] 
    public virtual Coffee Coffee { get; set; }
    
    [Required]
    [ForeignKey("CartId")]
    [JsonIgnore]
    public Guid CartId { get; set; }
    
    [JsonIgnore]
    public virtual Cart Cart { get; set; }
}