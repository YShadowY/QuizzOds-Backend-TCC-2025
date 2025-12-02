using System.Collections.Generic;

namespace QuizzOds.Domain.Entidades;

public class Ods : Entity
{
    public int Numero { get; set; }              // 1..17
    public string Titulo { get; set; } = null!;
    public string Resumo { get; set; } = null!;
    public string Conteudo { get; set; } = null!;
    public string RespostaBrasil { get; set; } = null!;

    public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
