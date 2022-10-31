using ITExpert.DAL.Context;
using ITExpert.DTO;
using ITExpert.Models;
using ITExpert.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITExpert.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _dbContext;

    public ClientService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateClientAsync(ClientCreateDto dto)
    {
        var client = new Client
        {
            Name = dto.Name,
            ClientContacts = dto.ClientContact.Select(x => new ClientContact()
                {
                    ContactType = x.ContactType,
                    ContactValue = x.ContactValue,
                }
            ).ToList()
        };

        await _dbContext.Clients.AddAsync(client);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// запрос, который возвращает наименование клиентов и кол-во контактов клиентов
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<ClientContactsCountDto>> GetWithContactsCountAsync()
    {
        var clientContactsCountDtos = await _dbContext.Clients
            .Select(x => new ClientContactsCountDto
            {
                Id = x.Id,
                Name = x.Name,
                ContactsCount = x.ClientContacts.Count
            }).ToListAsync();

        return clientContactsCountDtos;
    }

    /// <summary>
    /// запрос, который возвращает список клиентов, у которых есть более 2 контактов
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<ClientContactsCountDto>> GetClientsWithTwoMoreContactsAsync()
    {
        var clientContactsCountDtos = await _dbContext.Clients
            .Where(x => x.ClientContacts.Count > 2)
            .Select(x => new ClientContactsCountDto
            {
                Id = x.Id,
                Name = x.Name,
                ContactsCount = x.ClientContacts.Count
            })
            
            .ToListAsync();

        return clientContactsCountDtos;
    }
}