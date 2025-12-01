using Microsoft.EntityFrameworkCore;
using QuizzOds.Domain.Entidades;

namespace QuizzOds.Infrastructure.Data;

public class QuizzOdsDbContext(DbContextOptions<QuizzOdsDbContext> options) : DbContext(options)
{
    public DbSet<Question> Questions => Set<Question>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Question>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Title).IsRequired().HasMaxLength(255);
        });
    }
}
