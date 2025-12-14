using QuizOds.Application.Dtos.Question;


namespace QuizOds.Application.Dtos.Quiz;
public class QuizDto
{
    public int OdsNumero { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public List<QuestionDto> Questions { get; set; } = new();
}
