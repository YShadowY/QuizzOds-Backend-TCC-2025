using QuizzOds.Domain.Entidades;

namespace QuizzOds.Domain.Interfaces;

public interface IQuestionRepository
{
    Task<Question?> GetByIdAsync(Guid id);
    Task<IEnumerable<Question>> GetAllAsync();
    Task AddAsync(Question question);
    Task SaveChangesAsync();
}
