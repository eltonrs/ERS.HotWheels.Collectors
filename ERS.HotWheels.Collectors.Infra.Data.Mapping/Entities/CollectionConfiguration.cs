using ERS.HotWheels.Collectors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERS.HotWheels.Collectors.Infra.Data.Mapping.Entities
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.ToTable(nameof(Collection));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsUnicode() // Faz com que o tipo seja NVARCHAR (um VARCHAR que aceita unicode, ou seja, dois bytes por caractere)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.ReleaseDate)
                .IsRequired(false);

            builder.Property(x => x.EndDate)
                .IsRequired(false);

            builder.Property(x => x.TotalToyCar)
                .IsRequired(false);
        }
    }
}
