using Manage.Core.Configs;
using Manage.Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static IServiceCollection AddDbContextInjector(this IServiceCollection services, ConnectionStrings teste)
        {
            services.AddSingleton(teste);
            switch (teste.TipoString)
            {
                case "SQL":
                    SqlConnectionStringBuilder stringBuillder = new SqlConnectionStringBuilder()
                    {
                        DataSource = teste.Server,
                        InitialCatalog = teste.InitialCatalog,
                        UserID = teste.UserID,
                        Password = teste.Password
                    };
                    services.AddDbContext<ManageProductionDbContext>(options =>
                        options.UseSqlServer(stringBuillder.ConnectionString));
                    break;
                //case "MYSQL":
                //    MySqlConnectionStringBuilder stringBuillder1 = new MySqlConnectionStringBuilder()
                //    {
                //        Server = teste.Server,
                //        Database = teste.InitialCatalog,
                //        UserID = teste.UserID,
                //        Password = teste.Password,
                //        Port = 3306,
                //        //Port = XConfig.Porta.AsUInt32()
                //    };
                //    services.AddDbContext<ManageProductionDbContext>(options =>
                //        options.UseMySQL(stringBuillder1.ConnectionString));
                //    break;
            }
            
            

            return services;
        }
    }
}
