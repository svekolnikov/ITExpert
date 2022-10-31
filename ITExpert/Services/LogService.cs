using ITExpert.DAL.Context;
using ITExpert.Models;
using ITExpert.Services.Interfaces;

namespace ITExpert.Services;

public class LogService : ILogService
{
    private readonly ApplicationDbContext _dbContext;

    public LogService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task LogRequestAsync(RequestInfo requestInfo)
    {
        await _dbContext.AddAsync(requestInfo);
        await _dbContext.SaveChangesAsync();
    }
}