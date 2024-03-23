using ERS.HotWheels.Collectors.Domain.Entities;
using ERS.HotWheels.Collectors.Infra.Data.Mapping.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERS.HotWheels.Collectors.Infra.Data.Context
{
    public class HotWheelsCollectorsContext : DbContext
    {
        /* Há duas formas de mapear o modelo de dados (entidades x tabelas):
         * 
         * 1 - Expondo explicitamente a entidade através de uma propriedade genérica DbSet
         * 2 - Através do método OnModelCreating (esse método comumente utilizado para invocar os métodos de aplicação dos mapeamento das entidades)
         * 3 - Através de arquivos de configurações (desacoplamento de código)
         * 
         * Obs.: a forma com se configura, usando os métodos de extensão, é chamado de Fluent API
         */

        #region DataSets

        public DbSet<ToyCar> ToyCars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<WheelType> WheelTypes { get; set; }

        #endregion

        public HotWheelsCollectorsContext() { }

        public HotWheelsCollectorsContext(DbContextOptions<HotWheelsCollectorsContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"string connection", // pegar da connections string no appsettings
                    sqlServerOption =>
                    {
                        // Resiliência da conexão: habilita a opção do EF Core de reconectar em caso de falhas
                        sqlServerOption.EnableRetryOnFailure(
                            maxRetryCount: 2,
                            maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorNumbersToAdd: null
                        )
                        .MigrationsAssembly("ERS.HotWheels.Collectors.Infra.Data.Migrations");

                        //opt.MigrationsHistoryTable("EFMigrationsHistoryCurso"); // É possível alterar o nome da tabela onde são armazenados registros de execução do migrations (a tabela padrão do EF para histórico).
                        // IMPORTANTE: Isso deve ser feito antes do primeiro deploy, se não, a tabela anterior (nome padrão) continua.
                    }
                )
                .EnableSensitiveDataLogging(true);// CUIDADO!!! // Por padrão, o EF não exibe os valores dos parâmetros nos logs. Essa opção habilita a visualização dos parâmetros no console.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Configurações manuais. Devem ser aplicadas uma a uma */
            modelBuilder.ApplyConfiguration(new ToyCarConfiguration());
            modelBuilder.ApplyConfiguration(new CollectionConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new WheelTypeConfiguration());

            /* Configurações "automáticas". Configura todas as classes que herdam de IEntityTypeConfiguration<TEntity> que estão no assembly tal... */


        }
    }
}
