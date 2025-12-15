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

        if (ods is null)
            throw new Exception("ODS não encontrada");

        return new QuizDto
        {
            OdsNumero = ods.Numero,
            Titulo = ods.Titulo,

            Questions = ods.Quizzes
                .SelectMany(quiz => quiz.Questions)
                .Select(question => new QuestionDto
                {
                    Id = question.Id,
                    Texto = question.Texto,
                    OptionA = question.OptionA,
                    OptionB = question.OptionB,
                    OptionC = question.OptionC,
                    OptionD = question.OptionD
                })
                .ToList()
        };
    }
}
