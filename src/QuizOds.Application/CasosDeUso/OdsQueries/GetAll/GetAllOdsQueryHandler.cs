using MediatR;
using QuizOds.Application.CasosDeUso.OdsQueries.GetAll;
using QuizOds.Application.Dtos.Ods;
using QuizOds.Application.Dtos.Question;
using QuizOds.Domain.Interfaces;

public class GetAllOdsQueryHandler
    : IRequestHandler<GetAllOdsQuery, IEnumerable<OdsDto>>
{
    private readonly IOdsRepository _repository;

    public GetAllOdsQueryHandler(IOdsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OdsDto>> Handle(
        GetAllOdsQuery request,
        CancellationToken cancellationToken)
    {
        var odsList = await _repository.GetAllAsync();

        return odsList.Select(ods => new OdsDto
        {
            Id = ods.Id,
            Numero = ods.Numero,
            Titulo = ods.Titulo,
            Resumo = ods.Resumo,
            Conteudo = ods.Conteudo,
            ImageUrl = ods.ImageUrl,

            Questions = ods.Questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                Texto = q.Texto,
                OptionA = q.OptionA,
                OptionB = q.OptionB,
                OptionC = q.OptionC,
                OptionD = q.OptionD,
            }).ToList()

        }).ToList();
    }
}
