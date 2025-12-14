using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizOds.Application.CasosDeUso.OdsQueries.GetAll;
using QuizOds.Application.CasosDeUso.OdsQueries.GetPublic;
using QuizOds.Application.CasosDeUso.QuizQueries.GetQuizByOds;



namespace QuizOds.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OdsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OdsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // ENDPOINT PÚBLICO
    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var result = await _mediator.Send(new GetPublicOdsQuery());
        return Ok(result);

    }
    [HttpGet("{numero:int}/quiz")]
    public async Task<IActionResult> GetQuizByOds(int numero)
    {
        var quiz = await _mediator.Send(new GetQuizByOdsQuery(numero));
        return Ok(quiz);
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ods = await _mediator.Send(new GetAllOdsQuery());
        return Ok(ods);
    }

    [HttpGet("{numero:int}")]
    public async Task<IActionResult> GetByNumero(int numero)
    {
        var ods = await _mediator.Send(new GetOdsByNumeroQuery(numero));

        if (ods == null)
            return NotFound();

        return Ok(ods);
    }
}
