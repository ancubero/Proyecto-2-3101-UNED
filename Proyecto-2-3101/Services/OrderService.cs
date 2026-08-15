using Proyecto_2_3101.Data;
using Proyecto_2_3101.Extensions;
using Proyecto_2_3101.Models;
using Proyecto_2_3101.Models.Enums;
using Proyecto_2_3101.Repositories;

namespace Proyecto_2_3101.Services;

public class OrderService(IOrderRepository orderRepository, 
    IJobTypeRepository jobTypeRepository, 
    IUnitOfWork unitOfWork,
    IOrderStatusLogRepository orderStatusLogRepository) : IOrderService
{
    public async Task<OrderModel> AddAsync(int vehicleid, List<int> selectedJobTypeIds, int userId, int clientId)
    {

        var order = new OrderModel
        {
            ClientId = clientId,
            VehicleId = vehicleid,
            CreatedUserId = userId,
            CreatedAt = DateTimeOffset.Now,
            OrderStatus = OrderStatus.Pending,
            TotalPrice = 0
        };

        foreach (var jobTypeId in selectedJobTypeIds)
        {
            var jobItem = await jobTypeRepository.GetByIdAsync(jobTypeId);

            if (jobItem == null) throw  new Exception($"El servicio Id {jobTypeId} no ha sido encontrado");
            
            var detailRow = new JobOrderModel
            {
                JobTypeId = jobItem.JobTypeId,
                Price = jobItem.Price
            };
                
            order.JobOrders.Add(detailRow);
            order.TotalPrice += jobItem.Price;
        }
        
        return await orderRepository.AddAsync(order);
    }

    public async Task UpdateAsync(OrderModel order, int userId)
    {
        order.UpdatedUserId =  userId;
        order.UpdatedAt = DateTimeOffset.Now;
        await orderRepository.UpdateAsync(order);
    }

    public async Task<OrderModel?> GetByIdAsync(int id)
    {
        return await orderRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<OrderModel>> GetAllAsync()
    {
        return await orderRepository.GetAllAsync();
    }

    public async Task<IEnumerable<OrderModel>> GetByStatusAsync(OrderStatus status)
    {
        return await orderRepository.GetByStatusAsync(status);
    }

    public async Task<IEnumerable<OrderModel>> GetByClientIdAsync(int clientId)
    {
        return await orderRepository.GetByClientIdAsync(clientId);
    }

    public async Task<IEnumerable<OrderModel>> GetTodayOrdersAsync()
    {
        return await orderRepository.GetTodayOrdersAsync();
    }

    public async Task<IEnumerable<OrderModel>> GetFilteredOrdersAsync(DateTime? startDate, DateTime? endDate, OrderStatus? status)
    {
        return await orderRepository.GetFilteredOrdersAsync(startDate, endDate, status);
    }

    
    public async Task UpdateStatusAsync(OrderModel order, int userId)
    {

        await unitOfWork.BeginTransactionAsync();
        
        try
        {

            var orderLog = new ChangeOrderStatusLogModel
            {
                OrderId = order.Id,
                OrderStatus = order.OrderStatus.NextStatus(),
                RegisterDate = DateTimeOffset.Now,
                UserId = userId
            };

            order.OrderStatus = order.OrderStatus.NextStatus();
            order.UpdatedUserId = userId;
            order.UpdatedAt = DateTimeOffset.Now;
            orderRepository.PrepareUpdate(order);
            orderStatusLogRepository.Add(orderLog);
            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitTransactionAsync();

        } catch(Exception e)
        {
            await unitOfWork.RollbackTransactionAsync();
            throw new Exception($"Error cambiando la orden de estado: {e.Message}");
        }
    }
}