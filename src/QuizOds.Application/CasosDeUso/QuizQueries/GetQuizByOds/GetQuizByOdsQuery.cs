using MediatR;
using QuizOds.Application.Dtos.Quiz;

namespace QuizOds.Application.CasosDeUso.QuizQueries.GetQuizByOds;

public record GetQuizByOdsQuery(int Numero) : IRequest<QuizDto>;
