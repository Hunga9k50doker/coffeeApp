using Backend_Thue.Data;
using Backend_Thue.Interface;
using Backend_Thue.Models;

namespace Backend_Thue.Services;

public class UserService: IUserRepository
{
    private readonly MyDbContext _context;

    public UserService(MyDbContext context)
    {
        _context = context;
    }
    
    public User? Login(LoginUserModel loginModel)
    {
        var user = _context.Users.SingleOrDefault(user => user.Username == loginModel.Username);
        if(user == null)
        {
            return null;
        }

        return user.Password != loginModel.Password ? null : user;
    }
    
     public User? Register(RegisterUserModel registerModel)
    {
        var user = _context.Users.SingleOrDefault(user => user.Username == registerModel.Username);
        if(user != null)
        {
            return null;
        }
        
        user = new User
        {
            Username = registerModel.Username,
            Password = registerModel.Password,
            Email = registerModel.Email,
            Name = registerModel.Name
        };

        // Add user to database first to get ID
        _context.Users.Add(user);
        _context.SaveChanges();

        return user;
    }
}