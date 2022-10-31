using ITExpert.DTO;

namespace ITExpert.Services.Interfaces;

public interface IClientService
{
    Task CreateClientAsync(ClientCreateDto dto);
    Task<IEnumerable<ClientContactsCountDto>> GetWithContactsCountAsync();
    Task<IEnumerable<ClientContactsCountDto>> GetClientsWithTwoMoreContactsAsync();
}