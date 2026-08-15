namespace Proyecto_2_3101.Models.ViewModels;

public class JobOrderViewModel
{
    public OrderModel? Order { get; init; }
    public required IEnumerable<JobTypeModel> JobTypes { get; set; }
    public required VehicleModel Vehicle { get; set; }
    public required ClientModel Client { get; set; }
}