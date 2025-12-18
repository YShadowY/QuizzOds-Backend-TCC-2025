using Microsoft.EntityFrameworkCore;
using QuizOds.Application;
using QuizOds.Application.CasosDeUso.OdsQueries.GetAll;
using QuizOds.Infrastructure;
using QuizOds.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


// MediatR

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetAllOdsQuery).Assembly)
);


// Controllers

builder.Services.AddControllers();


// Swagger 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Application Layer

builder.Services.AddApplication();


// Infrastructure Layer

builder.Services.AddInfrastructure(builder.Configuration);


// CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});




builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


// BUILD

var app = builder.Build();


// SEED CONTROLADA 

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<QuizOdsDbContext>();

    // Aplica migrations automaticamente
    dbContext.Database.Migrate();

    // Só roda seed se NÃO existir ODS
    if (!dbContext.Ods.Any())
    {
        Console.WriteLine("🌱 Rodando seed inicial...");
        QuizOdsDbSeeder.Seed(dbContext);
    }
    else
    {
        Console.WriteLine("✅ Seed ignorada (dados já existem)");
    }
}

// =======================
// Middleware
// =======================

// Swagger 
app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler();
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.MapControllers();

// Health check 
app.MapGet("/health", () => Results.Ok("API Quiz ODS online 🚀"));

app.Run();
