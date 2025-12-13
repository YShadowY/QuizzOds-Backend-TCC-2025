using MediatR;
using QuizOds.Domain.Entities;

namespace QuizOds.Application.CasosDeUso.OdsQueries.GetAll;


public class GetAllOdsQuery : IRequest<IEnumerable<Ods>>
{
}
