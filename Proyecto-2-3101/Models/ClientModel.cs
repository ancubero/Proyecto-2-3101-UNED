using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_2_3101.Models;

public class ClientModel
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Cédula")]
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo dígitos en el campo {0}")]
    [StringLength(20)]
    public required string Identifier { get; init; }
    
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(255)]
    [Display(Name = "Nombre")]
    public required string FirstName { get; init; }
    
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Apellido")]
    [StringLength(255)]
    public required string LastName { get; init; }
    
    [NotMapped]
    public string Fullname => $"{FirstName} {LastName}";
    
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Número telefónico")]
    [StringLength(20)]
    [RegularExpression(@"^[24678][0-9]{3}[-\s]?[0-9]{4}$", ErrorMessage = "Ingrese un número telefónico válido de Costa Rica (8 dígitos).")]
    public required string PhoneNumber { get; init; }
    
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    [Display(Name = "Correo electrónico")]
    [StringLength(255)]
    public string? Email { get; init; }
    
    [Required]
    [Display(Name = "Feacha creación")]
    public DateTimeOffset CreationDate { get; set; }
    
    [Display(Name = "Fecha modificación")]
    public DateTimeOffset? ModifyDate { get; set; }
    
    [Required]
    public int CreatedBy { get; set; }
    
    public int? ModifiedBy { get; set; }

    [ForeignKey(nameof(CreatedBy))]
    public UserModel? CreatedByUser { get; init; }
    
    [ForeignKey(nameof(ModifiedBy))]
    public UserModel? ModifiedByUser { get; init; }
    
    [StringLength(1000, ErrorMessage = "Las observaciones no puede exceder los 1000 caracteres.")]
    [Display(Name = "Observaciones")]
    public string? Notes { get; set; }
}