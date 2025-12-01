using MediatR;

namespace QuizzOds.Application.CasosDeUso.Questions.Criar;

public record CriarQuestionCommand(
    string Title,
    string OptionA,
    string OptionB,
    string OptionC,
    string CorrectOption
) : IRequest<Guid>;
