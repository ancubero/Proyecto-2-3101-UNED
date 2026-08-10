using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Proyecto_2_3101.Models;

public class JobTypeModel
{
    [Key]
    public int JobTypeId { get; init; }
    
    [Required(ErrorMessage = "El campo Servicio es obligatorio")]
    [Display(Name = "Servicio")]
    [StringLength(50)]
    public required string Name { get; init; }
    
    [Display(Name = "Descripción")]
    [StringLength(1000)]
    public string? Description { get; init; }
 
    [Required(ErrorMessage = "El precio del servicio es requerido")]
    [Display(Name = "Precio")]
    public required decimal Price { get; init; }
    
    [Required(ErrorMessage = "La duración en minutos del servicio es requerido")]
    [Display(Name = "Duracion (Minutos)")]
    [Range(1, 480, ErrorMessage = "La duración debe ser entre 1 y 480 minutos")]
    public int DurationMinutes { get; init; }

    [Required(ErrorMessage = "El estado del servicio es requerido")]
    [Display(Name = "Estado")]
    public required bool IsActive { get; init; }
    
    public int CreatedByUserId { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public int? UpdatedByUserId { get; set; }
    
    public DateTimeOffset UpdatedAt { get; set; }
    
    [ForeignKey(nameof(CreatedByUserId))]
    public UserModel? CreatedByUser { get; init; }
    
    [ForeignKey(nameof(UpdatedByUserId))]
    public UserModel? UpdatedByUser { get; init; }
}