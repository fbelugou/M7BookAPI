using Microsoft.Extensions.DependencyInjection;

namespace BLL;

public class DomainOptions
{
    //Here you can add your custom options
}

public static class DomainExtension
{

    public static IServiceCollection AddDomain(this IServiceCollection services, Action<DomainOptions>? configure = null)
    {
        DomainOptions options = new();
        configure?.Invoke(options);
        
        //Register your services here

        return services;
    }
}