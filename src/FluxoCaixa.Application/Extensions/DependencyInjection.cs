namespace FluxoCaixa.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddScoped<IAdicionarFluxoCaixaService, AdicionarFluxoCaixaService>();
}