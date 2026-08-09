using Proyecto_2_3101.Models;
using Proyecto_2_3101.Repositories;

namespace Proyecto_2_3101.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<UserModel?> GetByIdAsync(int id)
    {
        return await userRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        return await userRepository.GetAllAsync();
    }

    public async Task AddAsync(UserModel userModel)
    {
        
        var user = await userRepository.GetByUsernameAsync(userModel.Username);

        if (user != null) throw new Exception($"El usuario {userModel.Username} ya existe");
        
        userModel.CreationDate = DateTimeOffset.Now;
        await userRepository.AddUserAsync(userModel);
    }

    public Task UpdateAsync(UserModel userModel)
    {
        userModel.ModifyDate = DateTimeOffset.Now;
        return userRepository.UpdateAsync(userModel);
    }

    public Task UpdateWithOutPasswordAsync(UserModel userModel)
    {
        userModel.ModifyDate = DateTimeOffset.Now;
        return userRepository.UpdateWithOutPasswordAsync(userModel);
    }
}