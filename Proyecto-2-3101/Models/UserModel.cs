using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_2_3101.Models;

public class UserModel
{
    [Key]
    public int UserId { get; init; }
    
    [Required(ErrorMessage = "El nombre completo del usuario es obligatorio")]
    [StringLength(255)]
    [DisplayName("Nombre Completo")]
    public string? FullName { get; init; }
    
    [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
    [StringLength(50)]
    [DisplayName("Usuario")] 
    public required string Username { get; init; }
    
    [StringLength(50)]
    [DisplayName("Contraseña")]
    public string? Password { get; init; }
    
    [Required]
    [DisplayName("Feacha creación")]
    public DateTimeOffset CreationDate { get; set; }
    
    [DisplayName("Fecha modificación")]
    public DateTimeOffset ModifyDate { get; set; }
}