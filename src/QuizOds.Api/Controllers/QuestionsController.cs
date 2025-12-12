using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizOds.Application.UseCases.Questions.Create;

namespace QuizOds.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create a new Question
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new
            {
                Id = result,
                Message = "Question created successfully."
            });
        }
    }
}
