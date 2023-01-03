using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Backend_Thue.Data;

public class Favourite
{
    [Key]
    public Guid ID { get; set; }
    
    [Required(ErrorMessage = "UserId is required")]
    [ForeignKey("User")]
    public Guid UserId { get; set; }

    [JsonIgnore]
    public virtual ICollection<FavouriteDetail> FavouriteDetails { get; set; }
    
    [JsonIgnore]
    public virtual User User { get; set; }
}