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
        public DbSet<Quiz> Quizzes => Set<Quiz>();
        public DbSet<Question> Questions => Set<Question>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ODS -> Quizzes (1:N)
            modelBuilder.Entity<Ods>()
                .HasMany(o => o.Quizzes)
                .WithOne(q => q.Ods)
                .HasForeignKey(q => q.OdsId)
                .OnDelete(DeleteBehavior.Cascade);

            // Quiz -> Questions (1:N)
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
