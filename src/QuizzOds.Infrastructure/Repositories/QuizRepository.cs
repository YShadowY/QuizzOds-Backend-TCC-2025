using QuizzOds.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using QuizzOds.Domain.Entidades;
using QuizzOds.Domain.Interfaces;
public class QuizRepository : IQuizRepository
{
    private readonly QuizzOdsDbContext _context;

    public QuizRepository(QuizzOdsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Quiz>> GetByOdsAsync(int numero)
    {
        return await _context.Quiz
            .Include(q => q.Ods)
            .Where(q => q.Ods.Numero == numero)
            .ToListAsync();
    }

    public async Task<Quiz?> GetByIdAsync(Guid id)
    {
        return await _context.Quiz
            .Include(q => q.Ods)
            .FirstOrDefaultAsync(q => q.Id == id);
    }
}
