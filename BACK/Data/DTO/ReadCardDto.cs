using System.ComponentModel.DataAnnotations;

namespace QuadroKanban.Data.DTO;

public class ReadCardDto
{
	public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? conteudo { get; set; }
    public string? lista { get; set; }
}
