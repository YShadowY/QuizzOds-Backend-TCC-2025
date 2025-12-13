using MediatR;
using QuizOds.Application.CasosDeUso.OdsQueries.GetAll;
using QuizOds.Domain.Entities;
using QuizOds.Domain.Interfaces;

public class GetAllOdsQueryHandler
    : IRequestHandler<GetAllOdsQuery, IEnumerable<Ods>>
{
    private readonly IOdsRepository _repository;

    public GetAllOdsQueryHandler(IOdsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Ods>> Handle(
        GetAllOdsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
