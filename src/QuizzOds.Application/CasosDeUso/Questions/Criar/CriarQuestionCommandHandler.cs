using MediatR;
using QuizzOds.Domain.Entidades;
using QuizzOds.Domain.Interfaces;

namespace QuizzOds.Application.CasosDeUso.Questions.Criar;

public class CreateQuestionHandler(IQuestionRepository repo) : IRequestHandler<CriarQuestionCommand, Guid>
{
    private readonly IQuestionRepository _repo = repo;

    public async Task<Guid> Handle(CriarQuestionCommand request, CancellationToken cancellationToken)
    {
        Question entity = new()
        {
            Title = request.Title,
            OptionA = request.OptionA,
            OptionB = request.OptionB,
            OptionC = request.OptionC,
            CorrectOption = request.CorrectOption
        };

        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();

        return entity.Id;
    }
}
