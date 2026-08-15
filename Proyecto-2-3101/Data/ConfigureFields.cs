using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Data;

public static class ConfigureFields
{

    extension(ModelBuilder modelBuilder)
    {
        public void PricePrecision()
        {
           modelBuilder.Entity<JobTypeModel>()
               .Property(j => j.Price)
               .HasPrecision(18, 2);
           
           modelBuilder.Entity<JobOrderModel>()
               .Property(j => j.Price)
               .HasPrecision(18, 2);
           
           modelBuilder.Entity<OrderModel>()
               .Property(o => o.TotalPrice)
               .HasPrecision(18, 2);
        }
    }
    
}