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

        public DbSet<Question> Questions { get; set; }
        public DbSet<Ods> Ods { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
    }
}
