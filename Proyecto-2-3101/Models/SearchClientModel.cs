using System.ComponentModel.DataAnnotations;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Models;

public class SearchClientModel
{
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Buscar")]
    public string? Search { get; init; }
    
    [Required(ErrorMessage = "Debe seleccionar un criterio de busqueda")]
    public SearchClientBy SearchClientBy { get; init; }
}