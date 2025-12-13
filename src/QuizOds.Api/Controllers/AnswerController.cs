using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizOds.Application.CasosDeUso.Answer;

namespace QuizOds.Api.Controllers;

[ApiController]
[Route("api/answer")]
public class AnswerController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnswerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitAnswer([FromBody] SubmitAnswerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
