using System.ComponentModel.DataAnnotations;

namespace QuadroKanban.Data.DTO;

public class LoginUsuarioDto
{
    [Required]
    public string? Login { get; set; }

    [Required]
    public string? Senha { get; set; }
}
