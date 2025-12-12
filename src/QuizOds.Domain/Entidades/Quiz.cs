using QuizOds.Domain.Entidades;
using QuizOds.Domain.Entities;


public class Quiz : Entity
{
    public Guid OdsId { get; set; }
    public Ods Ods { get; set; } = null!;

    public string Pergunta { get; set; } = null!;
    public string OptionA { get; set; } = null!;
    public string OptionB { get; set; } = null!;
    public string OptionC { get; set; } = null!;
    public string OptionD { get; set; } = null!;
    public string RespostaCorreta { get; set; } = null!;
}
