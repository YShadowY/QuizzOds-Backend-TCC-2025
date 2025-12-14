using QuizOds.Application.Dtos.Question;

namespace QuizOds.Application.Dtos.Ods;

public class OdsDto
{
    public Guid Id { get; set; }
    public int Numero { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Resumo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
    public string? ImagemUrl { get; set; }

    public string? ImageUrl { get; set; }
    public List<QuestionDto> Questions { get; set; } = new();

}
