using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Services;

public interface IUserService
{
    public Task<UserModel?> GetByIdAsync(int id);
    
    public Task<IEnumerable<UserModel>> GetAllAsync();
    
    public Task AddAsync(UserModel userModel);
    
    public Task UpdateAsync(UserModel userModel);

    Task UpdateWithOutPasswordAsync(UserModel userModel);
}