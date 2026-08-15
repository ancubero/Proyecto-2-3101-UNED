using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_2_3101.Models;

public class JobOrderModel
{
    public int OrderId { get; set; }
    public int JobTypeId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    [ForeignKey(nameof(OrderId))]
    public OrderModel Order { get; set; } = null!; 

    [ForeignKey(nameof(JobTypeId))]
    public JobTypeModel JobType { get; set; } = null!; 
}