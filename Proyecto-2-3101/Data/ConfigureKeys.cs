using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Data;

public static class ConfigureKeys
{
    extension(ModelBuilder modelBuilder)
    {
        public void CompositePrimaryKey()
        {
            modelBuilder.Entity<JobOrderModel>()
                .HasKey(jo => new {jo.OrderId, jo.JobTypeId});
        }
    }
}