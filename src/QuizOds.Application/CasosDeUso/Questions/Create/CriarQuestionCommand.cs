using MediatR;

namespace QuizOds.Application.UseCases.Questions.Create;

public class CreateQuestionCommand : IRequest<Guid>
{
    public Guid QuizId { get; set; }

    public string Texto { get; set; } = null!;

    public string OptionA { get; set; } = null!;
    public string OptionB { get; set; } = null!;
    public string OptionC { get; set; } = null!;
    public string OptionD { get; set; } = null!;

    public char RespostaCorreta { get; set; }
}
