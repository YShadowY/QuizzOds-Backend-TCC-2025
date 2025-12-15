using MediatR;
using QuizOds.Application.Dtos.Question;

public record SubmitAnswerCommand(
    Guid QuestionId,
    char SelectedOption
) : IRequest<AnswerResultDto>;
