namespace Proyecto_2_3101.Models.ViewModels;

public class ClientVehicleViewModel
{
    public required ClientModel Client { get; init; }
    public VehicleModel? Vehicle { get; init; }
}