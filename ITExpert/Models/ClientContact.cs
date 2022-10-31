using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ITExpert.Models;

public class ClientContact
{
    public int Id { get; set; }
    public int ClientId { get; set; }


    [Column(TypeName = "nvarchar(255)")]
    public string ContactType{ get; set; } = default!;

    [Column(TypeName = "nvarchar(255)")]
    public string ContactValue{ get; set; } = default!;
}