using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Data;

public static class ConfigureIndexes
{
    extension(ModelBuilder modelBuilder)
    {
        public void UserIndexes()
        {
            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }

        public void ClientsIndexes()
        {
            modelBuilder.Entity<ClientModel>()
                .HasIndex(c => c.Identifier)
                .IsUnique();
        
            modelBuilder.Entity<ClientModel>()
                .HasIndex(c => c.PhoneNumber)
                .IsUnique();
            
            modelBuilder.Entity<VehicleModel>()
                .HasOne(v => v.Client)
                .WithMany()
                .HasForeignKey(v => v.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<OrderModel>()
                .HasOne(o => o.Client)
                .WithMany()
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
        
        public void CreatedByForeignKeyIndexes()
        {
            modelBuilder.Entity<ClientModel>()
                .HasOne(c => c.CreatedByUser)
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<VehicleModel>()
                .HasOne(v => v.CreatedByUser)
                .WithMany()
                .HasForeignKey(v => v.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<JobTypeModel>()
                .HasOne(j => j.CreatedByUser)
                .WithMany()
                .HasForeignKey(j => j.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<OrderModel>()
                .HasOne(o => o.CreatedByUser)
                .WithMany()
                .HasForeignKey(o => o.CreatedUserId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }

        public void ModifiedByForeignKeyIndexes()
        {
            modelBuilder.Entity<ClientModel>()
                .HasOne(c => c.ModifiedByUser)
                .WithMany()
                .HasForeignKey(c => c.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<VehicleModel>()
                .HasOne(v => v.UpdatedByUser)
                .WithMany()
                .HasForeignKey(v => v.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<JobTypeModel>()
                .HasOne(j => j.UpdatedByUser)
                .WithMany()
                .HasForeignKey(j => j.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<OrderModel>()
                .HasOne(o => o.UpdatedByUser)
                .WithMany()
                .HasForeignKey(o => o.UpdatedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void OrderIndexes()
        {
            modelBuilder.Entity<OrderModel>()
                .HasOne(o => o.Vehicle)
                .WithMany()
                .HasForeignKey(o => o.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
        public void JobOrderIndexes()
        {
            modelBuilder.Entity<JobOrderModel>()
                .HasOne(jo => jo.Order)
                .WithMany(o => o.JobOrders)
                .HasForeignKey(jo => jo.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<JobOrderModel>()
                .HasOne(j => j.JobType)
                .WithMany()
                .HasForeignKey(j => j.JobTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void OrderLogs()
        {
            modelBuilder.Entity<ChangeOrderStatusLogModel>()
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void PaymentsIndexes()
        {
            modelBuilder.Entity<PaymentModel>()
                .HasOne(o => o.Order)
                .WithMany()
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}