using Manage.Core.Configs;
using Manage.Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace Manage.IOC.IOC
{
    public static class DbInjector
    {        
        public static IServiceCollection AddDbInjector(this IServiceCollection services)
        {
            services.AddScoped<ManageProductionDbContext>();
            //services.AddScoped<TokenService>();

            //services.AddScoped<IAddressLocationRepository, AddressLocationRepository>();

            return services;
        }

        public static IServiceCollection AddDbContextInjector(this IServiceCollection services, ConnectionStrings connectionStrings)
        {
            services.AddSingleton(connectionStrings);
            switch (connectionStrings.TipoString)
            {
                case "SQL":
                    SqlConnectionStringBuilder stringBuillderSqlServer = new SqlConnectionStringBuilder()
                    {
                        DataSource = connectionStrings.Server,
                        InitialCatalog = connectionStrings.InitialCatalog,
                        UserID = connectionStrings.UserID,
                        Password = connectionStrings.Password
                    };
                    services.AddDbContext<ManageProductionDbContext>(options =>
                        options.UseSqlServer(stringBuillderSqlServer.ConnectionString));
                    break;
                case "MYSQL":
                    MySqlConnectionStringBuilder stringBuillderMysql = new MySqlConnectionStringBuilder()
                    {
                        Server = connectionStrings.Server,
                        Database = connectionStrings.InitialCatalog,
                        UserID = connectionStrings.UserID,
                        Password = connectionStrings.Password,
                        Port = 3306,
                        //Port = XConfig.Porta.AsUInt32()
                    };
                    services.AddDbContext<ManageProductionDbContext>(options =>
                        options.UseSqlServer(stringBuillderMysql.ConnectionString));
                    break;
            }
            
            

            return services;
        }
    }
}
