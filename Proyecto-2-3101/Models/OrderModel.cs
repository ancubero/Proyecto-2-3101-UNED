using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Models;

public class OrderModel
{
    [Key]
    public int Id { get; init; }
    public int ClientId { get; init; }
    public int VehicleId { get; init; }
    public int CreatedUserId { get; init; }
    public int? UpdatedUserId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public decimal TotalPrice { get; set; }
    public ICollection<JobOrderModel> JobOrders { get; init; } = new List<JobOrderModel>();
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    [ForeignKey(nameof(ClientId))]
    public ClientModel? Client { get; init; }
    
    [ForeignKey(nameof(VehicleId))]
    public VehicleModel? Vehicle { get; init; }
    
    [ForeignKey(nameof(CreatedUserId))]
    public UserModel? CreatedByUser { get; init; }
    
    [ForeignKey(nameof(UpdatedUserId))]
    public UserModel? UpdatedByUser { get; init; }
    
    
    
    
}