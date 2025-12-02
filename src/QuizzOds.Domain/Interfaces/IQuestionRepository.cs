using QuizzOds.Domain.Entities;

namespace QuizzOds.Domain.Interfaces;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetByOdsAsync(Guid odsId);
    Task<Question?> GetByIdAsync(Guid id);
    Task AddAsync(Question question);
    Task UpdateAsync(Question question);
    Task DeleteAsync(Question question);
}
