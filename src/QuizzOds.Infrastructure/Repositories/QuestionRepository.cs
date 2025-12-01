using Microsoft.EntityFrameworkCore;
using QuizzOds.Domain.Entidades;
using QuizzOds.Domain.Interfaces;
using QuizzOds.Infrastructure.Data;

namespace QuizzOds.Infrastructure.Repositories;

public class QuestionRepository(QuizzOdsDbContext context) : IQuestionRepository
{
    private readonly QuizzOdsDbContext _context = context;

    public async Task AddAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
    }

    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        return await _context.Questions.AsNoTracking().ToListAsync();
    }

    public async Task<Question?> GetByIdAsync(Guid id)
    {
        return await _context.Questions.FindAsync(id);
    }

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
