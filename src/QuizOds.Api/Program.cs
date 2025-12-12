using Microsoft.EntityFrameworkCore;
using QuizOds.Application;
using QuizOds.Infrastructure;
using QuizOds.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


// 1. Controllers

builder.Services.AddControllers();


// 2. Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 3. Application Layer

builder.Services.AddApplication();


// 4. Infrastructure Layer (DbContext + Repositories)
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"CONN => {conn}");

builder.Services.AddInfrastructure(builder.Configuration);


// 5. CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});


builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();


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
