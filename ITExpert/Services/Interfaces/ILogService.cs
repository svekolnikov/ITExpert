using ITExpert.Models;

namespace ITExpert.Services.Interfaces;

public interface ILogService
{
    Task LogRequestAsync(RequestInfo requestInfo);
}