using Microsoft.EntityFrameworkCore;
using QuizOds.Domain.Entities;
using QuizOds.Domain.Interfaces;
using QuizOds.Infrastructure.Data;

namespace QuizOds.Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly QuizOdsDbContext _context;

    public QuestionRepository(QuizOdsDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Question question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
    }

    public async Task<Question?> GetByIdAsync(Guid id)
    {
        return await _context.Questions
            .Include(q => q.Ods)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<IEnumerable<Question>> GetByOdsAsync(Guid odsId)
    {
        return await _context.Questions
            .Where(x => x.OdsId == odsId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question != null)
        {
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }
    }
}
