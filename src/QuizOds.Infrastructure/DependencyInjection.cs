using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using QuizOds.Domain.Interfaces;
using QuizOds.Infrastructure.Data;
using QuizOds.Infrastructure.Repositories;

namespace QuizOds.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<QuizOdsDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(
                    configuration.GetConnectionString("DefaultConnection")
                )
            )
        );

        // 🔥 REGISTRO DOS REPOSITÓRIOS
        services.AddScoped<IOdsRepository, OdsRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuizRepository, QuizRepository>();

        return services;
    }
}
