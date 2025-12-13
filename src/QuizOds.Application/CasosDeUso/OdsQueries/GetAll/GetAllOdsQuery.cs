using MediatR;
using QuizOds.Application.Dtos.Ods;

namespace QuizOds.Application.CasosDeUso.OdsQueries.GetAll;

public record GetAllOdsQuery() : IRequest<IEnumerable<OdsDto>>;
