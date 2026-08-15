using System.ComponentModel.DataAnnotations;

namespace Proyecto_2_3101.Models.Enums;

public enum PaymentMethods
{
    [Display(Name = "Efectivo")]
    Cash,
    [Display(Name = "Tarjeta Crédito/Débito")]
    Card,
    [Display(Name = "SINPE Móvil")]
    SinpeMovil,
    [Display(Name = "Otro")]
    Other
}