using System.ComponentModel.DataAnnotations;

namespace Backend_Thue.Models;

public class CreateOrderModel
{
    [Required(ErrorMessage = "Tên người dùng phải có")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Vui lòng nhập số địa chỉ")]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "Số điện thoại phải có")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Email phải có")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Vui lòng nhập user id")]
    public Guid UserId { get; set; }
}