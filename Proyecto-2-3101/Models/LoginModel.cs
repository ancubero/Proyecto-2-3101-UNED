using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_2_3101.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Ingrese el Usuario")]
    [DisplayName("Usuario")]
    public string? Username { get; init; }
    [Required(ErrorMessage = "Ingrese la Contraseña del Usuario")]
    [DisplayName("Contraseña")]
    public string? Password { get; init; }
}