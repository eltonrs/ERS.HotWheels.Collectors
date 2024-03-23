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

        public HotWheelsCollectorsContext(DbContextOptions<HotWheelsCollectorsContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Dá pra fazer aqui (OnConfiguring)...
            //   tudo que foi feito aqui "ERS.HotWheels.Collectors.Infra.Data.Context.HotWheelsCollectorsContextConfiguration"
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
