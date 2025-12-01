using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzOds.Application.CasosDeUso.Questions.Criar;

namespace QuizzOds.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create(CriarQuestionCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok($"Endpoint só de exemplo, {id}");
    }
}
