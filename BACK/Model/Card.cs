using System.ComponentModel.DataAnnotations;

namespace QuadroKanban.Model;

public class Card
{
    [Key]
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string conteudo { get; set; }
    public string lista { get; set; }
}
