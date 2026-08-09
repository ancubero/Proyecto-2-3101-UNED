using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Services;

public interface ILoginService
{
    Task<UserModel> LoginAsync(LoginModel loginModel);
}