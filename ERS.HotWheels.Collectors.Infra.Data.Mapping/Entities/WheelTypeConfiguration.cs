using ERS.HotWheels.Collectors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERS.HotWheels.Collectors.Infra.Data.Mapping.Entities
{
    public class WheelTypeConfiguration : IEntityTypeConfiguration<WheelType>
    {
        public void Configure(EntityTypeBuilder<WheelType> builder)
        {
            builder.ToTable(nameof(WheelType));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LetterCode)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(x => x.DescriptionType)
                .IsUnicode()
                .IsRequired(false)
                .HasMaxLength(300);

            builder.Property(x => x.Notes)
                .IsUnicode()
                .IsRequired(false)
                .HasMaxLength(1000);
        }
    }
}
