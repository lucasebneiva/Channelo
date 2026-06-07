namespace ChanneloApi.Extensions;

public static class CorsExtensions
{
    public const string AngularPolicy = "AllowAngular";

    public static IServiceCollection AddAngularCors(
        this IServiceCollection services,
        IConfiguration config)
    {
        // Read from config so the URL isn't hardcoded
        var angularUrl = config["Cors:AngularUrl"] ?? "http://localhost:4200";

        services.AddCors(options =>
        {
            options.AddPolicy(AngularPolicy, policy =>
            {
                policy.WithOrigins(angularUrl)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }
}