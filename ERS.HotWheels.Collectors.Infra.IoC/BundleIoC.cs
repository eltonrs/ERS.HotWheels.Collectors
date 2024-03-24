using ERS.HotWheels.Collectors.Domain.Interfaces.Repositories;
using ERS.HotWheels.Collectors.Infra.Cqrs.Commands.Handlers.ToyCarEntity.Insert;
using ERS.HotWheels.Collectors.Infra.Data.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ERS.HotWheels.Collectors.Infra.IoC
{
    public static class BundleIoC
    {
        // ToDo : separar em classes diferentes

        public static void InstallIoC(this IServiceCollection services)
        {
            services.AddScoped<IToyCarRepository, ToyCarRepository>();

            services.AddMediatR(configurarion =>
            {
                configurarion.RegisterServicesFromAssemblies(
                    typeof(ToyCarInsertHandler).Assembly
                    //,typeof(ToyCarDeleteHandler).Assembly
                );
            });
        }
    }
}