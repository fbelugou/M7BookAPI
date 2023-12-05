using DAL.Repositories.Implementations.MariaDB;
using DAL.Repositories.Interfaces;
using DAL.Sessions.Implementations;
using DAL.Sessions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public enum DBType
{
    MariaDB,
    SQLServer,
    PostgreSQL,
    Oracle
}

public class DALOptions
{
    //Here you can add your custom options
    public DBType DBType { get; set; } = DBType.MariaDB;
    public string DBConnectionString { get; set; }
}

public static class DALExtension
{

    public static IServiceCollection AddDAL(this IServiceCollection services, Action<DALOptions> configure = null)
    {
        DALOptions options = new();
        configure?.Invoke(options);


        //Register your services here
        services.AddScoped<IDBSession>((services) => {
            
            switch(options.DBType)
            {
                case DBType.MariaDB:
                    return new DBSessionMariaDB(options.DBConnectionString);
                case DBType.SQLServer:
                    return new DBSessionSqlServer(options.DBConnectionString);
                case DBType.PostgreSQL:
                  //   return new DBSessionPostgreSQL(options.DBConnectionString);
                case DBType.Oracle:
                  //  return new DBSessionOracle(options.DBConnectionString);
                default:
                    throw new NotImplementedException();
                    

            }   
        });

        services.AddTransient<IUOW, UOW>((services) => new UOW(services.GetRequiredService<IDBSession>(),  options.DBType) );

        return services;
    }
}
