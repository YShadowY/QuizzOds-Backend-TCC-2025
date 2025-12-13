using QuizOds.Application.Dtos.Questions;

namespace QuizOds.Application.Dtos.Ods;

public class OdsPublicDto
{
    public Guid Id { get; set; }
    public int Numero { get; set; }
    public string Titulo { get; set; } = null!;
    public string Resumo { get; set; } = null!;
    public string Conteudo { get; set; } = null!;
    public string? ImageUrl { get; set; }

    public List<QuestionPublicDto> Questions { get; set; } = new();
}
