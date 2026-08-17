using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Models;

public class PaymentModel
{
    public int Id { get; init; }
    public required decimal AmountToPay { get; init; }
    public PaymentMethods PaymentMethod { get; init; }
    public DateTimeOffset PaymentDate { get; init; }
    public int OrderId { get; init; }
    
    [ForeignKey(nameof(OrderId))]
    public OrderModel? Order { get; init; }
}