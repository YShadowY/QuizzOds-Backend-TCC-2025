namespace QuizOds.Application.Dtos.Question;

public class QuestionDto
{
    public Guid Id { get; set; }
    public string Texto { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
}
