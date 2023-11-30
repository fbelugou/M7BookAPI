using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
namespace Domain;

public class DomainOptions
{
    //Here you can add your custom options
}

public static class DomainExtension
{

    public static IServiceCollection AddDomain(this IServiceCollection services, Action<DomainOptions> configure = null)
    {
        DomainOptions options = new();
        configure?.Invoke(options);
        
        //Register your services here

        //Register all validators from this assembly
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}