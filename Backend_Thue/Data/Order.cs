using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend_Thue.Data;

public class Order
{
    [Key]
    public Guid ID { get; set; }
    
    [Required(ErrorMessage = "Vui lòng nhập tên người đặt")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Vui lòng nhập số địa chỉ")]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Vui lòng nhập email")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; }
    
    // Auto generate
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime OrderDate { get; set; }
    
    [Required(ErrorMessage = "Vui lòng nhập user id")]
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    [JsonIgnore]
    public virtual User User { get; set; }
    
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}