using BLL.Implementations;
using BLL.Interfaces;
using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestUnitaire")]
namespace BLL;

public class BLLOptions
{
    
    //Here you can add your custom options
}

public static class BLLExtension
{

    public static IServiceCollection AddBLL(this IServiceCollection services, Action<BLLOptions> configure = null)
    {
        BLLOptions options = new();
        configure?.Invoke(options);
   
        
        //Register your BLL services here
        services.AddTransient<IBookStoreService, BookStoreService>();

        //Register DAL services
        services.AddDAL(o => o.DBType = DBType.SQLServer);


        return services;
    }
}
