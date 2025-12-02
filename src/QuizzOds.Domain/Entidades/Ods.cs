using QuizzOds.Domain.Common;
using QuizzOds.Domain.Entidades;

namespace QuizzOds.Domain.Entities;

public class Ods : Common.Entity
{
    public int Numero { get; set; }
    public string Titulo { get; set; } = null!;
    public string Resumo { get; set; } = null!;
    public string Conteudo { get; set; } = null!;
    public string RespostaBrasil { get; set; } = null!;

    // Relacionamento
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public object ImagemUrl { get; set; }
}
