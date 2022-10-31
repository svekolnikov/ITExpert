using ITExpert.DTO;
using ITExpert.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITExpert.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService _entitiesService;
        private readonly ILogger<DataController> _logger;

        public DataController(IDataService entitiesService, ILogger<DataController> logger)
        {
            _entitiesService = entitiesService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(IEnumerable<DataCreateDto> dtos)
        {
            try
            {
                await _entitiesService.CreateValuesRangeAsync(dtos);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            return Ok();
        }

        [HttpGet]
        public async Task<JsonResult> GetAll(string? valueFilter = "")
        {
            try
            {
                var entities = await _entitiesService.GetEntitiesAsync(valueFilter!);
                return new JsonResult(entities);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
