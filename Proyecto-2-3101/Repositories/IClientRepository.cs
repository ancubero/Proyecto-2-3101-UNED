using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public interface IClientRepository
{
    Task<ClientModel?> GetClientByIdAsync(int id);
    Task<ClientModel?> GetCLientByIdentityIdAsync(string identityId);
    Task<ClientModel?> GetClientByPhoneNumberAsync(string phoneNumber);
    Task<IEnumerable<ClientModel>> GetClientsAsync();
    Task AddClientAsync(ClientModel client);
    Task UpdateClientAsync(ClientModel client);
    Task<bool> ClientExistsByIdentifierAsync(string identifier);
    Task<bool> ClientExistsByPhoneNumberAsync(string phoneNumber);
    Task<IEnumerable<ClientModel>> SearchClientsByPhoneAsync(string phoneNumber);
    Task<IEnumerable<ClientModel>> SearchClientsByIdentifierAsync(string identifier);
    Task<IEnumerable<ClientModel>> SearchClientsByNameAsync(string name);
}