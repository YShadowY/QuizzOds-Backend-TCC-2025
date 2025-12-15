namespace QuizOds.Application.Dtos.Question;

public class SubmitAnswerDto
{
    public Guid QuestionId { get; set; }
    public char SelectedOption { get; set; } // A, B, C ou D
}
