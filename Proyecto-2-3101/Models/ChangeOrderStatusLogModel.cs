using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Models;

public class ChangeOrderStatusLogModel
{
    [Key]
    public int Id { get; init; }
    public int OrderId { get; init; }
    public int UserId { get; init; }
    public OrderStatus OrderStatus { get; init; }
    public DateTimeOffset RegisterDate { get; init; }
    [ForeignKey(nameof(UserId))]
    public UserModel? User { get; init; }
}