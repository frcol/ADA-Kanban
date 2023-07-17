using System.ComponentModel.DataAnnotations;

namespace QuadroKanban.Data.DTO;

public class CreateUsuarioDto
{
    [Required(ErrorMessage = "Login é um campo obrigatório")]
    public string? Login { get; set; }

    [Required(ErrorMessage = "Senha é um campo obrigatório")]
    [DataType(DataType.Password)]
    public string? Senha { get; set; }
}
