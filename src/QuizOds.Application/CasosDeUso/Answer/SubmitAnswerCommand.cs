using MediatR;
using QuizOds.Application.Dtos.Answer;

namespace QuizOds.Application.CasosDeUso.Answer;

public class SubmitAnswerCommand : IRequest<SubmitAnswerResultDto>
{
    public Guid QuestionId { get; set; }
    public string Resposta { get; set; } = string.Empty;
}
