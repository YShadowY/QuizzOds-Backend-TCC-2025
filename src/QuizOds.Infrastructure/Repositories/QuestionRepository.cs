using Microsoft.EntityFrameworkCore;
using QuizOds.Domain.Entities;
using QuizOds.Domain.Interfaces;
using QuizOds.Infrastructure.Data;

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
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<IEnumerable<Question>> GetByOdsIdAsync(Guid odsId)
    {
        return await _context.Questions
            .Where(q => q.OdsId == odsId)
            .ToListAsync();
    }
}
