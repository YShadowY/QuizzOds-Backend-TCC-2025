using QuizOds.Domain.Entities;

namespace QuizOds.Domain.Interfaces;

public interface IOdsRepository
{
    Task<IEnumerable<Ods>> GetAllAsync();
    Task<Ods?> GetByIdAsync(Guid id);
    Task<IEnumerable<Ods>> GetByNumeroAsync(int numero);
    Task AddAsync(Ods ods);
    Task UpdateAsync(Ods ods);
    Task DeleteAsync(Ods ods);
}
