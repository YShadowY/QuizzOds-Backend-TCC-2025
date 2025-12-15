using System;
using System.Collections.Generic;

namespace QuizOds.Domain.Entities;

public class Quiz
{
    public Guid Id { get; set; }

    public Guid OdsId { get; set; }
    public Ods Ods { get; set; } = null!;

    public ICollection<Question> Questions { get; set; } = new List<Question>();
}


