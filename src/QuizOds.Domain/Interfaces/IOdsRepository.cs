using QuizOds.Domain.Entities;

namespace QuizOds.Domain.Interfaces;

public interface IOdsRepository
{
    Task AddAsync(Ods ods);
    Task UpdateAsync(Ods ods);
    Task DeleteAsync(Ods ods);

    Task<IEnumerable<Ods>> GetAllAsync();
    Task<Ods?> GetByIdAsync(Guid id);
    Task<Ods?> GetByNumeroAsync(int numero);
}
