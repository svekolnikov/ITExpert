using ITExpert.Models;

namespace ITExpert.DTO;

public class ClientCreateDto
{
    public string Name { get; set; } = default!;

    public ICollection<ClientContactCreateDto> ClientContact { get; set; } = default!;

}