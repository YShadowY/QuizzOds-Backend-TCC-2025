using QuizOds.Domain.Entities;

public interface IQuestionRepository
{
    Task AddAsync(Question question);
    Task<Question?> GetByIdAsync(Guid id);
    Task<IEnumerable<Question>> GetByOdsIdAsync(Guid odsId);
}
