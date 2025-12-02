public interface IQuizRepository
{
    Task<IEnumerable<Quiz>> GetByOdsAsync(int numero);
    Task<Quiz?> GetByIdAsync(Guid id);
}
