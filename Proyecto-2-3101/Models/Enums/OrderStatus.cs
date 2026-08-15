using System.ComponentModel.DataAnnotations;

namespace Proyecto_2_3101.Models.Enums;

public enum OrderStatus
{
    [Display(Name = "Pendiente")]
    Pending,
    [Display(Name = "En Proceso")]
    Processing,
    [Display(Name = "Finalizado")]
    Finished,
    [Display(Name = "Pagado")]
    Paid,
    [Display(Name = "Entregado")]
    Completed
    
}