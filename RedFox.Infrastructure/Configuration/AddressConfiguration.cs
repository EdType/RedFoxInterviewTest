using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedFox.Domain.Entities;

namespace RedFox.Infrastructure.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Street).IsRequired();
        builder.Property(a => a.Suite).IsRequired();
        builder.Property(a => a.City).IsRequired();
        builder.Property(a => a.Zipcode).IsRequired();

        builder.HasOne(a => a.Geo)
            .WithOne(g => g.Address)
            .HasForeignKey<Geo>(g => g.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 