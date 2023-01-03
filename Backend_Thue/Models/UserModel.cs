using System.ComponentModel.DataAnnotations;

namespace Backend_Thue.Models;

public class LoginUserModel
{
    [Required(ErrorMessage = "Username phải có")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password phải có")]
    public string Password { get; set; }
}

public class RegisterUserModel: LoginUserModel
{
    [Required(ErrorMessage = "Name phải có")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Email phải có")]
    [EmailAddress(ErrorMessage = "Phải là email")]
    public string Email { get; set; }
}