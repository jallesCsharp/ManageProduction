using Manage.Core.Mediator;
using Manage.Core.Mediator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Manage.IOC.IOC
{
    public static class MediatorInjector
    {
        public static IServiceCollection AddMediatorInjector(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            return services;
        }
    }
}
