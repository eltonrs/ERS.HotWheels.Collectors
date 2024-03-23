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
            var connectionString = configuration.GetConnectionString("HTCollectors");

            services.AddDbContext<HotWheelsCollectorsContext>(builder =>
            {
                builder.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure(
                        maxRetryCount: 2,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null
                    )
                    .MigrationsAssembly("ERS.HotWheels.Collectors.Infra.Data.Migrations");

                    //opt.MigrationsHistoryTable("EFMigrationsHistoryCurso"); // É possível alterar o nome da tabela onde são armazenados registros de execução do migrations (a tabela padrão do EF para histórico).
                    // IMPORTANTE: Isso deve ser feito antes do primeiro deploy, se não, a tabela anterior (nome padrão) continua.
                })
                .EnableSensitiveDataLogging(true);// CUIDADO!!! // Por padrão, o EF não exibe os valores dos parâmetros nos logs. Essa opção habilita a visualização dos parâmetros no console.;
            });
        }
    }
}
