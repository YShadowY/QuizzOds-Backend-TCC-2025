using MediatR;
using QuizOds.Application.Dtos.Question;
using QuizOds.Application.Dtos.Quiz;
using QuizOds.Domain.Interfaces;

namespace QuizOds.Application.CasosDeUso.QuizQueries.GetQuizByOds;

public class GetQuizByOdsQueryHandler
    : IRequestHandler<GetQuizByOdsQuery, QuizDto>
{
    private readonly IOdsRepository _repository;

    public GetQuizByOdsQueryHandler(IOdsRepository repository)
    {
        _repository = repository;
    }

    public async Task<QuizDto> Handle(
        GetQuizByOdsQuery request,
        CancellationToken cancellationToken)
    {
        var ods = await _repository.GetByNumeroAsync(request.Numero);

        if (ods == null)
            throw new Exception("ODS não encontrada");

        return new QuizDto
        {
            OdsNumero = ods.Numero,
            Titulo = ods.Titulo, // OK → vem da tabela ODS

            Questions = ods.Questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                Texto = q.Texto,
                OptionA = q.OptionA,
                OptionB = q.OptionB,
                OptionC = q.OptionC,
                OptionD = q.OptionD
            }).ToList()
        };


    }
}
