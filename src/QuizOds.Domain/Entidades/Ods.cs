using System;
using System.Collections.Generic;

namespace QuizOds.Domain.Entities;

public class Ods
{
    public Guid Id { get; set; }
    public int Numero { get; set; }
    public string Titulo { get; set; } = null!;
    public string Resumo { get; set; } = null!;
    public string Conteudo { get; set; } = null!;
    public string? ImageUrl { get; set; }

    public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}

