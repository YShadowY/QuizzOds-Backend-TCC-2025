using MediatR;
using QuizOds.Application.Dtos.Answer;
using QuizOds.Domain.Interfaces;

namespace QuizOds.Application.CasosDeUso.Answer;

public class SubmitAnswerCommandHandler
    : IRequestHandler<SubmitAnswerCommand, SubmitAnswerResultDto>
{
    private readonly IQuestionRepository _questionRepository;

    public SubmitAnswerCommandHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<SubmitAnswerResultDto> Handle(
        SubmitAnswerCommand request,
        CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetByIdAsync(request.QuestionId);

        if (question == null)
        {
            return new SubmitAnswerResultDto
            {
                Correta = false,
                Mensagem = "Questão não encontrada"
            };
        }

        var correta =
            question.RespostaCorreta.ToString().Equals(
                request.Resposta,
                StringComparison.OrdinalIgnoreCase);

        return new SubmitAnswerResultDto
        {
            Correta = correta,
            Mensagem = correta
                ? "Resposta correta 🎉"
                : "Resposta incorreta ❌"
        };
    }
}
