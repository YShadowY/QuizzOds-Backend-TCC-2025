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
            .Include(q => q.Quiz)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<IEnumerable<Question>> GetByQuizIdAsync(Guid quizId)
    {
        return await _context.Questions
            .Where(q => q.QuizId == quizId)
            .ToListAsync();
    }
}
