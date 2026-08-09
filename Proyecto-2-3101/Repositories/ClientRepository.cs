using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Data;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public class ClientRepository(DataBaseContext context) : IClientRepository
{
    public async Task<ClientModel?> GetClientByIdAsync(int id)
    {
        return await context.Clients
            .Include(x => x.CreatedByUser)
            .Include(x => x.ModifiedByUser)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ClientModel?> GetCLientByIdentityIdAsync(string identityId)
    {
        return await context.Clients
            .Include(x => x.CreatedByUser)
            .Include(x => x.ModifiedByUser)
            .FirstOrDefaultAsync(x => x.Identifier.Equals(identityId));
    }

    public async Task<ClientModel?> GetClientByPhoneNumberAsync(string phoneNumber)
    {
        
        return await context.Clients
            .Include(x => x.CreatedByUser)
            .Include(x => x.ModifiedByUser)
            .FirstOrDefaultAsync(x => x.PhoneNumber.Equals(phoneNumber));
    }

    public async Task<IEnumerable<ClientModel>> GetClientsAsync()
    {
        return await context.Clients
            .Include(x => x.CreatedByUser)
            .Include(x => x.ModifiedByUser)
            .ToListAsync();
    }

    public async Task AddClientAsync(ClientModel client)
    {
        await context.Clients.AddAsync(client);
        await context.SaveChangesAsync();
    }

    public async Task UpdateClientAsync(ClientModel client)
    {
        context.Clients.Update(client);
        context.Entry(client).Property(x => x.CreatedBy).IsModified = false;
        context.Entry(client).Property(x => x.CreationDate).IsModified = false;
        await context.SaveChangesAsync();
    }

    public async Task<bool> ClientExistsByIdentifierAsync(string identifier)
    {
        return await context.Clients.AnyAsync(x => x.Identifier.Equals(identifier));
    }

    public async Task<bool> ClientExistsByPhoneNumberAsync(string phoneNumber)
    {
        return await context.Clients.AnyAsync(x => x.PhoneNumber.Equals(phoneNumber));
    }

    public async Task<IEnumerable<ClientModel>> SearchClientsByPhoneAsync(string phoneNumber)
    {
        var formattedPhone = $"%{phoneNumber}%";
        
        return await context.Clients
            .Where(x => EF.Functions.Like(x.PhoneNumber, formattedPhone))
            .Include(x => x.CreatedByUser)
            .Include(x => x.ModifiedByUser)
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientModel>> SearchClientsByIdentifierAsync(string identifier)
    {
        var formattedIdentifier = $"%{identifier}%";
        
        return await context.Clients
            .Where(x => EF.Functions.Like(x.Identifier, formattedIdentifier))
            .Include(x => x.CreatedByUser)
            .Include(x => x.ModifiedByUser)
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientModel>> SearchClientsByNameAsync(string name)
    {
        var formattedName = $"%{name}%";
        
        return await context.Clients
            .Where(x => EF.Functions.Like(x.FirstName, formattedName) ||
                        EF.Functions.Like(x.LastName, formattedName))
            .Include(x => x.CreatedByUser)
            .Include(x => x.ModifiedByUser)
            .ToListAsync();
    }
}