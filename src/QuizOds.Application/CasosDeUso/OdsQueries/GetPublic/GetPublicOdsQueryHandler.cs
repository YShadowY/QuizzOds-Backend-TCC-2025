using MediatR;
using QuizOds.Application.Dtos.Ods;
using QuizOds.Application.Dtos.Questions;
using QuizOds.Domain.Interfaces;

namespace QuizOds.Application.CasosDeUso.OdsQueries.GetPublic;

public class GetPublicOdsQueryHandler
    : IRequestHandler<GetPublicOdsQuery, IEnumerable<OdsPublicDto>>
{
    private readonly IOdsRepository _repository;

    public GetPublicOdsQueryHandler(IOdsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OdsPublicDto>> Handle(
        GetPublicOdsQuery request,
        CancellationToken cancellationToken)
    {
        var odsList = await _repository.GetAllAsync();

        return odsList.Select(ods => new OdsPublicDto
        {
            Id = ods.Id,
            Numero = ods.Numero,
            Titulo = ods.Titulo,
            Resumo = ods.Resumo,
            Conteudo = ods.Conteudo,
            ImageUrl = ods.ImageUrl,

            Questions = ods.Questions.Select(q => new QuestionPublicDto
            {
                Id = q.Id,
                Texto = q.Texto,
                OptionA = q.OptionA,
                OptionB = q.OptionB,
                OptionC = q.OptionC,
                OptionD = q.OptionD
            }).ToList()
        });
    }
}
