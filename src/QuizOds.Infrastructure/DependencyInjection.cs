using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizOds.Domain.Interfaces;
using QuizOds.Infrastructure.Data;
using QuizOds.Infrastructure.Repositories;

namespace QuizOds.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("❌ ConnectionString 'DefaultConnection' não encontrada no appsettings.json!");

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

            services.AddDbContext<QuizOdsDbContext>(options =>
                options.UseMySql(connectionString, serverVersion));

            // Registro de repositórios
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            return services;
        }
    }
}
