using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace QuizOds.Infrastructure.Data
{
    public class QuizOdsDbContextFactory
        : IDesignTimeDbContextFactory<QuizOdsDbContext>
    {
        public QuizOdsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuizOdsDbContext>();

            var connectionString =
                "Server=127.0.0.1;Port=3306;Database=quiz;User=root;Password=Shadow1342.;SslMode=None;";

            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 36))
            );

            return new QuizOdsDbContext(optionsBuilder.Options);
        }
    }
}
