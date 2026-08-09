using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Services;

public interface IVehicleService
{
    Task<IEnumerable<VehicleModel>> GetVehiclesAsync(int clientId);
    Task<VehicleModel?> GetVehicleAsync(int id);
    Task<VehicleModel?> GetVehicleAsync(string plateNumber);
    Task CreateVehicleAsync(VehicleModel vehicle, int userId, int clientId);
    Task UpdateVehicleAsync(VehicleModel vehicle, int userId);
}