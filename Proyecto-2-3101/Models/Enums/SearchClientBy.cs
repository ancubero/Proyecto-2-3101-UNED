using System.ComponentModel.DataAnnotations;

namespace Proyecto_2_3101.Models.Enums;

public enum SearchClientBy
{
    [Display(Name = "Nombre")]
    FullName,
    [Display(Name = "Teléfono")]
    Phone,
    [Display(Name = "Cédula")]
    Identifier
}