using Carter;

namespace Presentation;

public static class ConfigureServices
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddCarter();

        services.AddCors(options =>
        {
            options.AddPolicy("CORSPolicy",policy =>
            {
                policy.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            });
        });

        return services;
    }
}
