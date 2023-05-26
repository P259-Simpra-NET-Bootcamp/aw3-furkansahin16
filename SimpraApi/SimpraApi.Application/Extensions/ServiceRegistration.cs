using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SimpraApi.Application;
public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMapperService();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidationService();
        return services;

    }
    private static void AddMapperService(this IServiceCollection services)
    {
        services.AddSingleton(opt =>
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });
            return mapperConfig.CreateMapper();
        });
    }
    private static void AddValidationService(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation(opt => opt.DisableDataAnnotationsValidation = true)
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.Configure<ApiBehaviorOptions>(cfg => cfg.SuppressModelStateInvalidFilter = true);
    }
}