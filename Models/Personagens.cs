using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDradAndDrop.Models;

[Table("personagens")]
public record Personagens
{
    public int Id {get; set;}
    public string? Nome {get; set;}
    public string? Imagens {get; set;}
}