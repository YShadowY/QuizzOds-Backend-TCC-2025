namespace QuizzOds.Domain.Entidades;

public class Question : Entity
{
    public string Title { get; set; } = null!;
    public string OptionA { get; set; } = null!;
    public string OptionB { get; set; } = null!;
    public string OptionC { get; set; } = null!;
    public string CorrectOption { get; set; } = null!;
}
