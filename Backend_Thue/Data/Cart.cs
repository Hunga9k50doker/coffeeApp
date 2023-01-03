using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Backend_Thue.Data;

public class Cart
{
    [Key]
    public Guid ID { get; set; }
    
    [Required(ErrorMessage = "UserId is required")]
    [ForeignKey("User")]
    [JsonIgnore]
    public Guid UserId { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<CartDetail> CartDetails { get; set; }
    
    public virtual User User { get; set; }
}