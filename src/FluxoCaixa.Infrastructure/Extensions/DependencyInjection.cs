namespace ControleFluxoCaixa.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddScoped<IUnitOfWork, UnitOfWork>();

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration Configuration)
        => services.AddDbContext<ControleFluxoCaixaDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ConexaoPadrao"]));
}