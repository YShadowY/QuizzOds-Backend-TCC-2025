using Microsoft.EntityFrameworkCore;
using QuizzOds.Domain.Entities;

public class QuizzOdsDbContext : DbContext
{
    public DbSet<Ods> Ods { get; set; } = null!;
    public DbSet<Quiz> Quiz { get; set; } = null!;

    public QuizzOdsDbContext(DbContextOptions<QuizzOdsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ods>(builder =>
        {
            builder.ToTable("Ods");

            builder.Property(o => o.Numero).IsRequired();
            builder.Property(o => o.Titulo).HasMaxLength(255).IsRequired();
            builder.Property(o => o.Resumo).IsRequired();
            builder.Property(o => o.Conteudo).IsRequired();
            builder.Property(o => o.RespostaBrasil).IsRequired();
            builder.Property(o => o.ImagemUrl).IsRequired();
        });

        modelBuilder.Entity<Quiz>(builder =>
        {
            builder.ToTable("Quiz");

            builder.Property(q => q.Pergunta).IsRequired();
            builder.Property(q => q.RespostaCorreta).IsRequired();
        });
    }
}
