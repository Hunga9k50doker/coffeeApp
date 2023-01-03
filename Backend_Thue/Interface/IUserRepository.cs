using Backend_Thue.Data;
using Backend_Thue.Models;

namespace Backend_Thue.Interface;

public interface IUserRepository
{
    User? Login(LoginUserModel loginUserModel);
    User? Register(RegisterUserModel registerUserModel);
}