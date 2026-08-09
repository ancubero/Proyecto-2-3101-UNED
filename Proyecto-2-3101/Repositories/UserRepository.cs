using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Data;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public class UserRepository(DataBaseContext context) : IUserRepository
{
    public async Task<UserModel?> GetByUsernameAsync(string username)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task AddUserAsync(UserModel userModel)
    {
        await context.Users.AddAsync(userModel);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<UserModel?> GetByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task UpdateAsync(UserModel userModel)
    {
        context.Users.Update(userModel);
        context.Entry(userModel).Property(x => x.CreationDate).IsModified = false;
        await context.SaveChangesAsync();
    }

    public async Task UpdateWithOutPasswordAsync(UserModel userModel)
    {
        context.Users.Update(userModel);
        context.Entry(userModel).Property(x => x.CreationDate).IsModified = false;
        context.Entry(userModel).Property(x => x.Password).IsModified = false;
        await context.SaveChangesAsync();
    }
}