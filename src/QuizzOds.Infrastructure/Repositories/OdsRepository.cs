using Microsoft.EntityFrameworkCore;
using QuizzOds.Domain.Entities;
using QuizzOds.Domain.Interfaces;
using QuizzOds.Infrastructure.Data;

namespace QuizzOds.Infrastructure.Repositories;

public class OdsRepository : IOdsRepository
{
    private readonly QuizzOdsDbContext _context;

    public OdsRepository(QuizzOdsDbContext context) => _context = context;

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
