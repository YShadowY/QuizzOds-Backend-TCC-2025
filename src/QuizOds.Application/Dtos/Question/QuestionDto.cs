namespace QuizOds.Application.Dtos.Questions;

public class QuestionDto
{
    public Guid Id { get; set; }
    public string Texto { get; set; } = null!;
    public string OptionA { get; set; } = null!;
    public string OptionB { get; set; } = null!;
    public string OptionC { get; set; } = null!;
    public string OptionD { get; set; } = null!;
    public string RespostaCorreta { get; set; } = null!;

}
