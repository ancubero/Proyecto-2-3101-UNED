using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Services;

public interface IClientService
{
    Task<ClientModel?> GetClientByIdAsync(int id);
    Task<ClientModel?> GetCLientByIdentityIdAsync(string identityId);
    Task<IEnumerable<ClientModel>> GetClientsAsync();
    Task AddClientAsync(ClientModel client, int userId);
    Task UpdateClientAsync(ClientModel client, int userId);
    Task<IEnumerable<ClientModel>> SearchClientsByPhoneAsync(string phoneNumber);
    Task<IEnumerable<ClientModel>> SearchClientsByIdentifierAsync(string identifier);
    Task<IEnumerable<ClientModel>> SearchClientsByNameAsync(string name);
}