using QuizOds.Domain.Entities;
using QuizOds.Domain.Common;
using QuizOds.Domain.Entidades;

namespace QuizOds.Domain.Entities;

public class Ods : Common.Entity
{
    public int Numero { get; set; }
    public string Titulo { get; set; } = null!;
    public string Resumo { get; set; } = null!;
    public string Conteudo { get; set; } = null!;
    public string RespostaBrasil { get; set; } = null!;

    // Relacionamento
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public string? ImageUrl { get; set; }

}
