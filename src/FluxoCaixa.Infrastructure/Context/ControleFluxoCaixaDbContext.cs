using Microsoft.Extensions.Logging;

namespace ControleFluxoCaixa.Infrastructure.Context;

public class ControleFluxoCaixaDbContext : DbContext
{
    public ControleFluxoCaixaDbContext(DbContextOptions<ControleFluxoCaixaDbContext> options) : base(options)
    {
    }

    public virtual DbSet<ControleLancamento> ControleLancamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControleFluxoCaixaDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();

        optionsBuilder
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}