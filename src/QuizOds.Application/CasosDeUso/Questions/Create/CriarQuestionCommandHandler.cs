using MediatR;
using QuizOds.Domain.Entities;
using QuizOds.Domain.Interfaces;


namespace QuizOds.Application.UseCases.Questions.Create;

public class CreateQuestionCommandHandler
    : IRequestHandler<CreateQuestionCommand, Guid>
{
    private readonly IQuestionRepository _repository;

    public CreateQuestionCommandHandler(IQuestionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = new Question
        {
            OdsId = request.OdsId,
            QuestionText = request.Question,
            OptionA = request.OptionA,
            OptionB = request.OptionB,
            OptionC = request.OptionC,
            OptionD = request.OptionD,
            CorrectAnswer = request.CorrectAnswer
        };

        await _repository.AddAsync(question);

        return question.Id;
    }
}
