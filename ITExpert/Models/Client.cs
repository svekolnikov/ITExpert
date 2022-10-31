using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ITExpert.Models;

public class Client
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(255)")] 
    public string Name { get; set; } = default!;

    public ICollection<ClientContact> ClientContacts { get; set; } = default!;
}