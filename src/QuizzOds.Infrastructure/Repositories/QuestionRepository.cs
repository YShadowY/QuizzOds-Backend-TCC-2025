using Microsoft.EntityFrameworkCore;
using QuizzOds.Domain.Entities;
using QuizzOds.Domain.Interfaces;
using QuizzOds.Infrastructure.Data;

namespace QuizzOds.Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly QuizzOdsDbContext _context;

    public QuestionRepository(QuizzOdsDbContext context) => _context = context;

    public async Task AddAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Question question)
    {
        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
    }

    public async Task<Question?> GetByIdAsync(Guid id)
        => await _context.Questions.FirstOrDefaultAsync(q => q.Id == id);

    public async Task<IEnumerable<Question>> GetByOdsAsync(Guid odsId)
        => await _context.Questions.Where(q => q.OdsId == odsId).ToListAsync();

    public async Task UpdateAsync(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
    }
}
