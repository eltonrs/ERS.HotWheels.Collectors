using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERS.HotWheels.Collectors.Infra.Data.Context
{
    public static class HotWheelsCollectorsContextConfiguration
    {
        public static void InstallHotWheelsCollectorsContext(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("HTCContext");

            services.AddDbContext<HotWheelsCollectorsContext>(builder =>
            {
                //builder.UseSqlServer(connectionString);
                // Configurações já implementadas em: ERS.HotWheels.Collectors.Infra.Context.OnConfiguring(...)
            });
        }
    }
}
