using QuizOds.Domain.Entidades;
using QuizOds.Domain.Entities;

namespace QuizOds.Domain.Entities;

public class Question : Entity
{
    public Guid OdsId { get; set; }
    public Ods Ods { get; set; } = null!;

    public string Texto { get; set; } = null!;
    public string OptionA { get; set; } = null!;
    public string OptionB { get; set; } = null!;
    public string OptionC { get; set; } = null!;
    public string OptionD { get; set; } = null!;
    public char RespostaCorreta { get; set; }
}
