using System.ComponentModel.DataAnnotations;

namespace Proyecto_2_3101.Models.Enums;

public enum VehicleType
{
    [Display(Name = "Automóvil")]
    Automobile,
    [Display(Name = "Motocicleta")]
    Motorcycle,
    [Display(Name = "SUV")]
    Suv,
    [Display(Name = "Pick-Up")]
    Pickup,
    [Display(Name = "Otro")]
    Other
    
}