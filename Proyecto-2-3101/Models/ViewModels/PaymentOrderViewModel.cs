using System.ComponentModel.DataAnnotations;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Models.ViewModels;

public class PaymentOrderViewModel
{
    public required OrderModel Order { get; set; }
    [Required(ErrorMessage = "Al menos una opción de pago es requerida")]
    public PaymentMethods PaymentMethod { get; set; }
}