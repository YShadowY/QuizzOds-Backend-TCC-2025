using QuizOds.Domain.Entidades;
using QuizOds.Domain.Entities;


public class Quiz : Entity
{
    public Guid OdsId { get; set; }
    public Ods Ods { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public ICollection<Question> Questions { get; set; } = new List<Question>();
}
