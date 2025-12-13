using MediatR;
using QuizOds.Domain.Entities;

namespace QuizOds.Application.CasosDeUso.OdsQueries.GetAll;


public class GetOdsByNumeroQuery : IRequest<Ods?>
{
    public int Numero { get; }

    public GetOdsByNumeroQuery(int numero)
    {
        Numero = numero;
    }
}
