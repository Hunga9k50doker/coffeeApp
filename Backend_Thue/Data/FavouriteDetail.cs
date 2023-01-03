using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend_Thue.Data;

public class FavouriteDetail
{
    [Key]
    public Guid ID { get; set; }

    [Required]
    [JsonIgnore]
    public Guid CoffeeId { get; set; }
    [ForeignKey("CoffeeId")]
    public virtual Coffee Coffee { get; set; }
    
    [Required]
    [ForeignKey("FavouriteId")]
    [JsonIgnore]
    public Guid FavouriteId { get; set; }
    [JsonIgnore]
    public virtual Favourite Favourite { get; set; }
}