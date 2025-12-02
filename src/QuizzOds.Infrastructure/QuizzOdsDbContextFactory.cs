using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace QuizzOds.Infrastructure.Data
{
    public class QuizzOdsDbContextFactory : IDesignTimeDbContextFactory<QuizzOdsDbContext>
    {
        public QuizzOdsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuizzOdsDbContext>();

            var connectionString =
                "Server=127.0.0.1;Database=quizz_ods;User=root;Password=Shadow1342.;SslMode=None;TreatTinyAsBoolean=true";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new QuizzOdsDbContext(optionsBuilder.Options);
        }
    }
}
