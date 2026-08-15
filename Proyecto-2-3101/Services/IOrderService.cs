using Proyecto_2_3101.Models;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Services;

public interface IOrderService
{
    Task<OrderModel> AddAsync(int vehicleid, List<int> selectedJobTypeIds, int userId, int clientId);
    Task UpdateAsync(OrderModel order, int userId);
    Task<OrderModel?> GetByIdAsync(int id);
    Task<IEnumerable<OrderModel>> GetAllAsync();
    Task<IEnumerable<OrderModel>> GetByStatusAsync(OrderStatus status);
    Task<IEnumerable<OrderModel>> GetByClientIdAsync(int clientId);
    Task<IEnumerable<OrderModel>> GetTodayOrdersAsync();
    Task<IEnumerable<OrderModel>> GetFilteredOrdersAsync(DateTime? startDate, DateTime? endDate, OrderStatus? status);
    Task UpdateStatusAsync(OrderModel order, int userId);
}