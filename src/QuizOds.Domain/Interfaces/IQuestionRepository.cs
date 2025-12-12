using QuizOds.Domain.Entities;
using QuizOds.Domain.Entities;

namespace QuizOds.Domain.Interfaces;

public interface IQuestionRepository
{
    Task AddAsync(Question question);
    Task<Question?> GetByIdAsync(Guid id);
    Task<IEnumerable<Question>> GetByOdsAsync(Guid odsId);
    Task UpdateAsync(Question question);
    Task DeleteAsync(Guid id);
}
