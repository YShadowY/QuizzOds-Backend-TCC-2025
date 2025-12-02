using System.Collections.Generic;

namespace QuizzOds.Domain.Entidades;

public class Quiz : Entity
{
    public string Titulo { get; set; } = null!;

    public Guid? OdsId { get; set; }
    public Ods? Ods { get; set; }

    public ICollection<Question> Questions { get; set; } = new List<Question>();
}
