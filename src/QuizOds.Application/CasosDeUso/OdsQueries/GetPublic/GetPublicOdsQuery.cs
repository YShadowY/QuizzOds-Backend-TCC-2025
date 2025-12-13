using MediatR;
using QuizOds.Application.Dtos.Ods;

namespace QuizOds.Application.CasosDeUso.OdsQueries.GetPublic;

public record GetPublicOdsQuery() : IRequest<IEnumerable<OdsPublicDto>>;
