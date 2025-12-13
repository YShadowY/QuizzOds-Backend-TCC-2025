using QuizOds.Domain.Entities;

namespace QuizOds.Domain.Interfaces;

public interface IOdsRepository
{
    Task<IEnumerable<Ods>> GetAllAsync();
    Task<Ods?> GetByNumeroAsync(int numero);
}
