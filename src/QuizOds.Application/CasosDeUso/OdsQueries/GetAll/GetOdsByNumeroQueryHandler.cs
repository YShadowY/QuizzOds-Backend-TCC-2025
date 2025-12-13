using MediatR;
using QuizOds.Domain.Entities;
using QuizOds.Domain.Interfaces;

namespace QuizOds.Application.CasosDeUso.OdsQueries.GetAll;


public class GetOdsByNumeroQueryHandler : IRequestHandler<GetOdsByNumeroQuery, Ods?>
{
    private readonly IOdsRepository _repository;

    public GetOdsByNumeroQueryHandler(IOdsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Ods?> Handle(GetOdsByNumeroQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByNumeroAsync(request.Numero);
    }
}
