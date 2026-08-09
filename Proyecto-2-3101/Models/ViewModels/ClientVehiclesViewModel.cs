namespace Proyecto_2_3101.Models.ViewModels;

public class ClientVehiclesViewModel
{
    public ClientModel? Client { get; set; } = null;
    public IEnumerable<VehicleModel>? Vehicles { get; set; } = [];
}