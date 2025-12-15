using MediatR;
using QuizOds.Application.Dtos.Ods;

public class GetOdsByNumeroQuery : IRequest<OdsDto?>
{
    public int Numero { get; }

    public GetOdsByNumeroQuery(int numero)
    {
        Numero = numero;
    }
}
