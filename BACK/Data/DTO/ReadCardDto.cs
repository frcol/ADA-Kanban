using System.ComponentModel.DataAnnotations;

namespace QuadroKanban.Data.DTO;

public class ReadCardDto
{
    public string? Titulo { get; set; }
    public string? conteudo { get; set; }
    public string? lista { get; set; }
}
