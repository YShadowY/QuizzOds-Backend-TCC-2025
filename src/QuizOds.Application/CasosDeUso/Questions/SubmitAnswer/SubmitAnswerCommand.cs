using MediatR;
using QuizOds.Application.Dtos.Question;

namespace QuizOds.Application.CasosDeUso.Questions.SubmitAnswer;

public class SubmitAnswerCommand : IRequest<AnswerResultDto>
{
    public Guid QuestionId { get; }
    public char SelectedOption { get; }

    public SubmitAnswerCommand(Guid questionId, char selectedOption)
    {
        QuestionId = questionId;
        SelectedOption = selectedOption;
    }
}
