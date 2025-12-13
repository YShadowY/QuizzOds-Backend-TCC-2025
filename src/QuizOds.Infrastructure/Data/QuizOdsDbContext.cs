using Microsoft.EntityFrameworkCore;
using QuizOds.Domain.Entities;

namespace QuizOds.Infrastructure.Data
{
    public class QuizOdsDbContext : DbContext
    {
        public QuizOdsDbContext(DbContextOptions<QuizOdsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ods> Ods => Set<Ods>();
        public DbSet<Quiz> Quiz => Set<Quiz>();
        public DbSet<Question> Questions => Set<Question>();

    }
}
