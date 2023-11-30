using DAL.Repositories.Implementations.MariaDB;
using DAL.Repositories.Interfaces;
using DAL.Sessions.Implementations;
using DAL.Sessions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public class DALOptions
{
    //Here you can add your custom options
}

public static class DALExtension
{

    public static IServiceCollection AddDAL(this IServiceCollection services, Action<DALOptions> configure = null)
    {
        DALOptions options = new();
        configure?.Invoke(options);


        //Register your services here

        services.AddScoped<IDBSession, DBSessionMariaDB>();

        services.AddTransient<IBookRepository, BookRepositoryMariaDB>();

        return services;
    }
}
