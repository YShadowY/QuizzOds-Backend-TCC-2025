using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizOds.Application.Dtos.Question;
using QuizOds.Infrastructure.Data;

namespace QuizOds.Application.CasosDeUso.Questions.SubmitAnswer;

public class SubmitAnswerCommandHandler : IRequestHandler<SubmitAnswerCommand, AnswerResultDto>
{
    private readonly QuizOdsDbContext _context;

    public SubmitAnswerCommandHandler(QuizOdsDbContext context)
    {
        _context = context;
    }

    public async Task<AnswerResultDto> Handle(SubmitAnswerCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == request.QuestionId, cancellationToken);

        if (question is null)
            throw new Exception("Pergunta não encontrada");

        var isCorrect =
            char.ToUpper(request.SelectedOption) ==
            char.ToUpper(question.RespostaCorreta);

        return new AnswerResultDto
        {
            IsCorrect = isCorrect,
            CorrectOption = question.RespostaCorreta
        };
    }
}
