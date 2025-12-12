using QuizOds.Infrastructure.Data;
using QuizOds.Domain.Entities;
using QuizOds.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;   

namespace QuizOds.Infrastructure.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly QuizOdsDbContext _context;

    public QuizRepository(QuizOdsDbContext context)
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
