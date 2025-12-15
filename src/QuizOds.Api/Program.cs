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


// Connection string log (debug)

var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"CONN => {conn}");

if (string.IsNullOrWhiteSpace(conn))
{
    Console.WriteLine("❌ DefaultConnection NÃO foi carregada");
}
else
{
    Console.WriteLine("✅ ConnectionString carregada com sucesso");
}


// CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});


// Exception handling

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


// BUILD APP

var app = builder.Build();


// SEED (AGORA NO LUGAR CERTO)

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<QuizOdsDbContext>();
    QuizOdsDbSeeder.Seed(dbContext);
}


// Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
