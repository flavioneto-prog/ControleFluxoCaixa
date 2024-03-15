namespace FluxoCaixa.API.Configurations;

public static class VersioningConfig
{
    public static IApiVersioningBuilder AddVersioningConfig(this IServiceCollection services)
        => services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
}