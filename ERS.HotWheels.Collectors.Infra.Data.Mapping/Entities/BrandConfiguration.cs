using ERS.HotWheels.Collectors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERS.HotWheels.Collectors.Infra.Data.Mapping.Entities
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable(nameof(Brand));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
