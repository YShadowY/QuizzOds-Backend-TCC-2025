namespace QuizOds.Application.Dtos.Answer;

public class SubmitAnswerResultDto
{
    public bool Correta { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}
