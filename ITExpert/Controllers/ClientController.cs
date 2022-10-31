using ITExpert.DTO;
using ITExpert.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITExpert.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientService clientService, ILogger<ClientController> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateDto dto)
        {
            try
            {
                await _clientService.CreateClientAsync(dto);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
        }

        [HttpGet("with-contacts-count")]
        public async Task<IActionResult> GetWithContactsCount()
        {
            try
            {
                var clients = await _clientService.GetWithContactsCountAsync();
                return Ok(clients);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        [HttpGet("with-two-more-contacts")]
        public async Task<IActionResult> GetClientsWithTwoMoreContacts()
        {
            try
            {
                var clients = await _clientService.GetClientsWithTwoMoreContactsAsync();
                return Ok(clients);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
