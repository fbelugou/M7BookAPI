using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public class DALOptions
{
    //Here you can add your custom options
}

public static class DALExtension
{

    public static IServiceCollection AddBLL(this IServiceCollection services, Action<DALOptions>? configure = null)
    {
        DALOptions options = new();
        configure?.Invoke(options);


        //Register your services here

        return services;
    }
}
