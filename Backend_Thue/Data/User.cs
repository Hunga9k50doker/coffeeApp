using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_Thue.Data;

public class User
{
    [Key]
    public Guid ID { get; set; }
    
    [Required(ErrorMessage = "Tên người dùng phải có")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Username phải có")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password phải có")]
    public string Password { get; set; }
    
    public string? Address { get; set; }

    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string? Email { get; set; }
    
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    public string? PhoneNumber { get; set; }
    
    [JsonIgnore]
    public virtual Favourite Favourite { get; set; }
    
    [JsonIgnore]
    public virtual Cart Cart { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; }
}