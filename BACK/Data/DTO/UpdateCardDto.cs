using System.ComponentModel.DataAnnotations;

namespace QuadroKanban.Data.DTO;

public class UpdateCardDto
{
    [Required]
    public string Titulo { get; set; }
    [Required]
    public string conteudo { get; set; }
    [Required]
    public string lista { get; set; }
}
