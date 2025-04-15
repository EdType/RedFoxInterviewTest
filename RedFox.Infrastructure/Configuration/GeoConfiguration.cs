using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedFox.Domain.Entities;

namespace RedFox.Infrastructure.Configuration;

public class GeoConfiguration : IEntityTypeConfiguration<Geo>
{
    public void Configure(EntityTypeBuilder<Geo> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Lat).IsRequired();
        builder.Property(g => g.Lng).IsRequired();
    }
} 