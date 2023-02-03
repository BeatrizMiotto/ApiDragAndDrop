using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDradAndDrop.Models;

[Table("lista")]
public record Lista
{
    public int Id {get; set;}
    public string? Nome {get; set;}
}