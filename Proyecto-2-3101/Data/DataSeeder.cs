using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Data;

public static class DataSeeder
{
    public static void SeedUsers(this ModelBuilder builder)
    {
        builder.Entity<UserModel>().HasData(new UserModel
        {
            UserId = -1,
            FullName = "Administrador",
            Username =  "admin",
            Password = "123",
            CreationDate = DateTimeOffset.Parse("2026-07-08T00:00:00Z")
        });
    }
    
}