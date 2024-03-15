namespace ConsolidadoDiario.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddScoped<IObterConsolidadoDiarioService, ObterConsolidadoDiarioService>();
}