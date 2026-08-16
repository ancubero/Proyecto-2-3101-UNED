using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Models;

public class PaymentModel
{
    public int Id { get; init; }
    public required decimal AmountToPay { get; set; }
    public PaymentMethods PaymentMethod { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public int OrderId { get; set; }
    
    [ForeignKey(nameof(OrderId))]
    public OrderModel? Order { get; init; }
}