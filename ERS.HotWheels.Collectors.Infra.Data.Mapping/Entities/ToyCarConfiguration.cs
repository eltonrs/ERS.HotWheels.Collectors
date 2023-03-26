using ERS.HotWheels.Collectors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERS.HotWheels.Collectors.Infra.Data.Mapping.Entities
{
    public class ToyCarConfiguration : IEntityTypeConfiguration<ToyCar>
    {
        public void Configure(EntityTypeBuilder<ToyCar> builder)
        {
            builder.ToTable(nameof(ToyCar));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsUnicode() // Faz com que o tipo seja NVARCHAR (um VARCHAR que aceita unicode, ou seja, dois bytes por caractere)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.ReleaseYear)
                .IsRequired();

            builder.Property(x => x.BrandId)
                .IsRequired();

            builder.Property(x => x.CollectionId)
                .IsRequired();

            builder.Property(x => x.CollectionIndex)
                .IsRequired(false);

            builder.Property(x => x.Tampography)
                .IsUnicode()
                .IsRequired(false)
                .HasMaxLength(1000);

            builder.Property(x => x.WheelTypeId)
                .IsRequired(false);

            builder.HasOne(a => a.WheelType)
                .WithMany(b => b.ToyCars)
                .HasForeignKey(a => a.WheelTypeId);
                //.IsRequired(); FK NULL ???

            builder.HasOne(a => a.Collection)
                .WithMany(b => b.ToyCars)
                .HasForeignKey(a => a.CollectionId);

        }
    }
}
