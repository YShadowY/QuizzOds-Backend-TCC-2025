using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizOds.Application.CasosDeUso.Questions.SubmitAnswer;
using QuizOds.Application.Dtos.Question;

namespace QuizOds.Api.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("answer")]
    public async Task<IActionResult> SubmitAnswer(
        [FromBody] SubmitAnswerDto dto)
    {
        var result = await _mediator.Send(
            new SubmitAnswerCommand(
                dto.QuestionId,
                dto.SelectedOption
            )
        );

        return Ok(result);
    }
}
