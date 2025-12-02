using System;

namespace QuizzOds.Domain.Entidades;

public class Question : Entity
{
    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; } = null!;

    public string Title { get; set; } = null!;
    public string OptionA { get; set; } = null!;
    public string OptionB { get; set; } = null!;
    public string OptionC { get; set; } = null!;
    public string OptionD { get; set; } = null!;
    public string CorrectOption { get; set; } = null!; // "A", "B", "C" ou "D"
}

