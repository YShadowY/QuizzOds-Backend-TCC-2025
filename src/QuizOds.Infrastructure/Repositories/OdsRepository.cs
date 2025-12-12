using Microsoft.EntityFrameworkCore;
using QuizOds.Infrastructure.Data;
using QuizOds.Domain.Entities;
using QuizOds.Domain.Interfaces;

namespace QuizOds.Infrastructure.Repositories;

public class OdsRepository : IOdsRepository
{
    private readonly QuizOdsDbContext _context;

    public OdsRepository(QuizOdsDbContext context) => _context = context;

    public async Task AddAsync(Ods ods)
    {
        await _context.Ods.AddAsync(ods);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Ods ods)
    {
        _context.Ods.Remove(ods);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Ods>> GetAllAsync()
        => await _context.Ods.Include(o => o.Questions).ToListAsync();

    public async Task<Ods?> GetByIdAsync(Guid id)
        => await _context.Ods.Include(o => o.Questions).FirstOrDefaultAsync(o => o.Id == id);

    public async Task<IEnumerable<Ods>> GetByNumeroAsync(int numero)
        => await _context.Ods.Where(o => o.Numero == numero).ToListAsync();

    public async Task UpdateAsync(Ods ods)
    {
        _context.Ods.Update(ods);
        await _context.SaveChangesAsync();
    }
}
