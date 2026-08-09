using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Models;

public class VehicleModel
{
    [Key]
    public int IdVehicle { get; init; }
    
    public int ClientId { get; set; }
    
    [Required(ErrorMessage = "La placa del vehiculo es requerido.")]
    [Display(Name = "Placa")]
    [StringLength(10)]
    public required string PlateNumber { get; init; }
    
    [Required(ErrorMessage = "La marca del vehículo es requerida.")]
    [Display(Name = "Marca")]
    [StringLength(20)]
    public required string Brand { get; init; }
    
    [Display(Name = "Modelo")]
    [StringLength(20)]
    public string? Model { get; init; }
    
    [StringLength(30)]
    public string? Color { get; init; }
    
    [Required(ErrorMessage = "El tipo de vehículo es requerido.")]
    [Display(Name = "Tipo")]
    public required VehicleType Type { get; init; }
    
    public int CreatedByUserId { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public int? UpdatedByUserId { get; set; }
    
    public DateTimeOffset UpdatedAt { get; set; }
    
    [ForeignKey(nameof(CreatedByUserId))]
    public UserModel? CreatedByUser { get; init; }
    
    [ForeignKey(nameof(UpdatedByUserId))]
    public UserModel? UpdatedByUser { get; init; }
    
    [ForeignKey(nameof(ClientId))]
    public ClientModel? Client { get; init; }
}