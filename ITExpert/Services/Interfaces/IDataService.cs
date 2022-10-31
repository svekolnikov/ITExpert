using ITExpert.DTO;
using ITExpert.Models;

namespace ITExpert.Services.Interfaces;

public interface IDataService
{
    Task CreateValuesRangeAsync(IEnumerable<DataCreateDto> dto);
    Task<IEnumerable<Data>> GetEntitiesAsync(string valueFilter);
}