using Microsoft.EntityFrameworkCore;
using QuizOds.Domain.Entities;
using QuizOds.Domain.Interfaces;
using QuizOds.Infrastructure.Data;

namespace QuizOds.Infrastructure.Repositories;

public class OdsRepository : IOdsRepository
{
    private readonly QuizOdsDbContext _context;

    public OdsRepository(QuizOdsDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Ods ods)
    {
        _context.Ods.Add(ods);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ods ods)
    {
        _context.Ods.Update(ods);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Ods ods)
    {
        _context.Ods.Remove(ods);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Ods>> GetAllAsync()
    {
        return await _context.Ods
            .Include(o => o.Quizzes)
                .ThenInclude(q => q.Questions)
            .ToListAsync();
    }

    public async Task<Ods?> GetByIdAsync(Guid id)
    {
        return await _context.Ods
            .Include(o => o.Quizzes)
                .ThenInclude(q => q.Questions)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Ods?> GetByNumeroAsync(int numero)
    {
        return await _context.Ods
            .Include(o => o.Quizzes)
                .ThenInclude(q => q.Questions)
            .FirstOrDefaultAsync(o => o.Numero == numero);
    }

}
