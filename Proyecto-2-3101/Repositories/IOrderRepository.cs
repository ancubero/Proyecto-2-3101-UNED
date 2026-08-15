using Proyecto_2_3101.Models;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Repositories;

public interface IOrderRepository
{
    Task<OrderModel> AddAsync(OrderModel order);
    Task UpdateAsync(OrderModel order);
    void PrepareUpdate(OrderModel order);
    Task<OrderModel?> GetByIdAsync(int id);
    Task<IEnumerable<OrderModel>> GetAllAsync();
    Task<IEnumerable<OrderModel>> GetByStatusAsync(OrderStatus status);
    Task<IEnumerable<OrderModel>> GetByClientIdAsync(int clientId);
    Task<IEnumerable<OrderModel>> GetTodayOrdersAsync();
    Task<IEnumerable<OrderModel>> GetFilteredOrdersAsync(DateTime? startDate, DateTime? endDate, OrderStatus? status);
    
}