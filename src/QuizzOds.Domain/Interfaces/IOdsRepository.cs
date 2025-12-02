using QuizzOds.Domain.Entities;

namespace QuizzOds.Domain.Interfaces;

public interface IOdsRepository
{
    Task<IEnumerable<Ods>> GetAllAsync();
    Task<Ods?> GetByIdAsync(Guid id);
    Task<IEnumerable<Ods>> GetByNumeroAsync(int numero);
    Task AddAsync(Ods ods);
    Task UpdateAsync(Ods ods);
    Task DeleteAsync(Ods ods);
}
