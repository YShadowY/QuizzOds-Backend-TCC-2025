using MediatR;
using QuizOds.Application.Dtos.Ods;
using QuizOds.Application.Dtos.Question;
using QuizOds.Domain.Interfaces;

public class GetOdsByNumeroQueryHandler
    : IRequestHandler<GetOdsByNumeroQuery, OdsDto?>
{
    private readonly IOdsRepository _repository;

    public GetOdsByNumeroQueryHandler(IOdsRepository repository)
    {
        _repository = repository;
    }

    public async Task<OdsDto?> Handle(
        GetOdsByNumeroQuery request,
        CancellationToken cancellationToken)
    {
        var ods = await _repository.GetByNumeroAsync(request.Numero);

        if (ods == null)
            return null;

        return new OdsDto
        {
            Id = ods.Id,
            Numero = ods.Numero,
            Titulo = ods.Titulo,
            Resumo = ods.Resumo,
            Conteudo = ods.Conteudo,
            ImageUrl = ods.ImageUrl,

            Questions = ods.Quizzes
                .SelectMany(qz => qz.Questions)
                .Select(q => new QuestionDto
                {
                    Id = q.Id,
                    Texto = q.Texto,
                    OptionA = q.OptionA,
                    OptionB = q.OptionB,
                    OptionC = q.OptionC,
                    OptionD = q.OptionD
                })
                .ToList()
        };
    }
}
