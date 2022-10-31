using ITExpert.DAL.Context;
using ITExpert.DTO;
using ITExpert.Models;
using ITExpert.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITExpert.Services;

public class DataService : IDataService
{
    private readonly ApplicationDbContext _dbContext;

    public DataService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateValuesRangeAsync(IEnumerable<DataCreateDto> dto)
    {
        //Parse value to Int, Order by Code
        var entities = dto
            .Select(x => new Data
            {
                Code = int.Parse(x.Code),
                Value = x.Value,
            })
            .OrderBy(x => x.Code);

        //Clear table
        var all = _dbContext.Datas;
        _dbContext.RemoveRange(all);

        //Add range
        await _dbContext.AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Data>> GetEntitiesAsync(string valueFilter)
    {
        var entities = await _dbContext.Datas
            .Where(x => x.Value.Contains(valueFilter))
            .ToListAsync();
        return entities;
    }
}