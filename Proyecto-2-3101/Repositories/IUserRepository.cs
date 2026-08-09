using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public interface IUserRepository
{
    Task<UserModel?> GetByUsernameAsync(string username);
    Task AddUserAsync(UserModel userModel);
    Task<IEnumerable<UserModel>> GetAllAsync();
    Task<UserModel?> GetByIdAsync(int id); 
    Task UpdateAsync(UserModel userModel);
    Task UpdateWithOutPasswordAsync(UserModel userModel);
}