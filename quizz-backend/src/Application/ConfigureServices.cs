using Application.Common.Interfaces.Managers;
using Application.Data;
using Application.Managers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;
public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddScoped<IQuestionManager, QuestionManager>();
        services.AddScoped<IOptionManager, OptionManager>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
