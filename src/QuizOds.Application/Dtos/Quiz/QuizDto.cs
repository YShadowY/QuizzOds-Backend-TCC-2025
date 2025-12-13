using QuizOds.Application.Dtos.Questions;

namespace QuizOds.Application.Dtos.Quiz;

public class QuizDto
{
    public Guid Id { get; set; }
    public int OdsNumero { get; set; }

    public List<QuestionDto> Questions { get; set; } = new();
}
