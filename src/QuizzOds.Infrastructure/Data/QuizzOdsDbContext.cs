using Microsoft.EntityFrameworkCore;
using QuizzOds.Domain.Entidades;

namespace QuizzOds.Infrastructure.Data;

public class QuizzOdsDbContext : DbContext
{
    public QuizzOdsDbContext(DbContextOptions<QuizzOdsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ods> Ods => Set<Ods>();
    public DbSet<Quiz> Quizzes => Set<Quiz>();
    public DbSet<Question> Questions => Set<Question>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ods>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Numero).IsRequired();
            b.Property(x => x.Titulo).IsRequired().HasMaxLength(255);
            b.Property(x => x.Resumo).IsRequired();
            b.Property(x => x.Conteudo).IsRequired();
            b.Property(x => x.RespostaBrasil).IsRequired();
        });

        modelBuilder.Entity<Quiz>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Titulo).IsRequired();

            b.HasOne(x => x.Ods)
                .WithMany(o => o.Quizzes)
                .HasForeignKey(x => x.OdsId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Question>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Title).IsRequired().HasMaxLength(255);

            b.HasOne(x => x.Quiz)
                .WithMany(q => q.Questions)
                .HasForeignKey(x => x.QuizId);
        });
    }
}
