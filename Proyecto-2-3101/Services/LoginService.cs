using Proyecto_2_3101.Exceptions;
using Proyecto_2_3101.Models;
using Proyecto_2_3101.Repositories;

namespace Proyecto_2_3101.Services;

public class LoginService(IUserRepository userRepository) : ILoginService
{
    public async Task<UserModel> LoginAsync(LoginModel loginModel)
    {

        if (loginModel.Username == null) throw new InvalidLoginException("Usuario no debe ser en blanco");
        
        var user = await userRepository.GetByUsernameAsync(loginModel.Username);
        
        if(user == null) throw new InvalidLoginException("Usuario no encontrado");

        var authResult = user.Password == loginModel.Password;
    
        return !authResult ? throw new InvalidLoginException() : user;
    }
}