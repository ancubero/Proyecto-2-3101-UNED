using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Data;
using Proyecto_2_3101.Models;
using Proyecto_2_3101.Models.Enums;
using Proyecto_2_3101.Models.ViewModels;

namespace Proyecto_2_3101.Repositories;

public class OrderRepository(DataBaseContext context) : IOrderRepository
{
    public async Task<OrderModel> AddAsync(OrderModel order)
    {
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task UpdateAsync(OrderModel order)
    {
        PrepareUpdate(order);
        await context.SaveChangesAsync();
    }

    public void PrepareUpdate(OrderModel order)
    {
        context.Orders.Update(order);
        context.Entry(order).Property(o => o.CreatedUserId).IsModified = false;
        context.Entry(order).Property(o => o.CreatedAt).IsModified = false;
        context.Entry(order).Property(o => o.ClientId).IsModified = false;
        context.Entry(order).Property(o => o.VehicleId).IsModified = false;
    }

    public async Task<OrderModel?> GetByIdAsync(int id)
    {
        return await context.Orders
            .Include(c => c.Client)
            .Include(v => v.Vehicle)
            .Include(cu => cu.CreatedByUser)
            .Include(uu => uu.UpdatedByUser)
            .Include(j => j.JobOrders )
                .ThenInclude(j => j.JobType)
            .Where(o => o.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<OrderModel>> GetAllAsync()
    {
        return await context.Orders
            .Include(c => c.Client)
            .Include(v => v.Vehicle)
            .Include(cu => cu.CreatedByUser)
            .Include(uu => uu.UpdatedByUser)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderModel>> GetByStatusAsync(OrderStatus status)
    {
        return await context.Orders
            .Include(c => c.Client)
            .Include(v => v.Vehicle)
            .Include(cu => cu.CreatedByUser)
            .Include(uu => uu.UpdatedByUser)
            .Where(o => o.OrderStatus == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderModel>> GetByClientIdAsync(int clientId)
    {
        return await context.Orders
            .Include(c => c.Client)
            .Include(v => v.Vehicle)
            .Include(cu => cu.CreatedByUser)
            .Include(uu => uu.UpdatedByUser)
            .Where(o => o.ClientId == clientId)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderModel>> GetTodayOrdersAsync()
    {
        var startTime = DateTimeOffset.Now.Date;
        var endTime = startTime.AddDays(1);
        
        return await  context.Orders
            .Include(c => c.Client)
            .Include(v => v.Vehicle)
            .Include(cu => cu.CreatedByUser)
            .Include(uu => uu.UpdatedByUser)
            .Where(o => o.CreatedAt >= startTime && o.CreatedAt < endTime)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderModel>> GetFilteredOrdersAsync(DateTime? startDate, DateTime? endDate, OrderStatus? status)
    {
        var query = context.Orders
            .Include(o => o.Client)
            .Include(v => v.Vehicle)
            .AsQueryable();

        if (startDate.HasValue)
        {
            DateTimeOffset startBoundary = DateTime.SpecifyKind(startDate.Value.Date, DateTimeKind.Local);
            query = query.Where(o => o.CreatedAt >= startBoundary);
        }
        
        if (endDate.HasValue)
        {
            DateTimeOffset endBoundary = DateTime.SpecifyKind(endDate.Value.Date.AddDays(1), DateTimeKind.Local);
            query = query.Where(o => o.CreatedAt < endBoundary);
        }
        
        if (status.HasValue)
        {
            query = query.Where(o => o.OrderStatus == status.Value);
        }
        
        return await query
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync();
    }

    public async Task<OrderStatusReportViewModel> GetOrderByStatusAsync()
    {
        var groupedOrders = await context.Orders
            .GroupBy(o => o.OrderStatus)
            .Select(g => new StatusCountItem()
            {
                Status = g.Key,
                Count = g.Count(),
                TotalRevenue = g.Sum(o => o.TotalPrice)
            }).ToListAsync();

        var report = new OrderStatusReportViewModel
        {
            StatusBreakdown =  groupedOrders,
            TotalOrdersCount =  groupedOrders.Sum(o => o.Count),
            GrandTotalPrice = groupedOrders.Sum(i => i.TotalRevenue)
        };


        return report;
    }
}