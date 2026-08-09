using Proyecto_2_3101.Models;
using Proyecto_2_3101.Repositories;

namespace Proyecto_2_3101.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    public async Task<ClientModel?> GetClientByIdAsync(int id)
    {
        return await clientRepository.GetClientByIdAsync(id);
    }

    public async Task<ClientModel?> GetCLientByIdentityIdAsync(string identityId)
    {
        return  await clientRepository.GetCLientByIdentityIdAsync(identityId);
    }

    public async Task<IEnumerable<ClientModel>> GetClientsAsync()
    {
        return await clientRepository.GetClientsAsync();
    }

    public async Task AddClientAsync(ClientModel client, int userId)
    {

        var clientExistsByIdentifier = await clientRepository.ClientExistsByIdentifierAsync(client.Identifier);
        
        if (clientExistsByIdentifier) throw new Exception($"El cliente con la cédula {client.Identifier} ya existe ");
        
        var clientExistsByPhoneNumber = await clientRepository.ClientExistsByPhoneNumberAsync(client.PhoneNumber);

        if (clientExistsByPhoneNumber) throw new Exception($"El número de teléfono {client.PhoneNumber} ya se encuentra registrado");
        
        
        client.CreatedBy = userId;
        client.CreationDate = DateTimeOffset.Now;
        await clientRepository.AddClientAsync(client);
    }

    public async Task UpdateClientAsync(ClientModel client, int userId)
    {
        client.ModifiedBy = userId;
        client.ModifyDate = DateTimeOffset.Now;
        await clientRepository.UpdateClientAsync(client);
    }

    public async Task<IEnumerable<ClientModel>> SearchClientsByPhoneAsync(string phoneNumber)
    {
        return await clientRepository.SearchClientsByPhoneAsync(phoneNumber);
    }

    public async Task<IEnumerable<ClientModel>> SearchClientsByIdentifierAsync(string identifier)
    {
        return await clientRepository.SearchClientsByIdentifierAsync(identifier);
    }

    public async Task<IEnumerable<ClientModel>> SearchClientsByNameAsync(string name)
    {
        return await clientRepository.SearchClientsByNameAsync(name);
    }
}