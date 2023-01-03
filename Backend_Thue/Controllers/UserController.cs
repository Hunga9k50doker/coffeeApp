using System.Net;
using Backend_Thue.Data;
using Backend_Thue.Interface;
using Backend_Thue.Models;
using Backend_Thue.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Thue.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController: ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUserModel loginUserModel)
    {
        try
        {
            var user = _userRepository.Login(loginUserModel);

            return user == null ? StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy người dùng hoặc sai mật khẩu") : Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterUserModel registerUserModel)
    {
        try
        {
            var user = _userRepository.Register(registerUserModel);

            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Người dùng đã có");
            }

            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}