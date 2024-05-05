using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechECommerce.Core.Models;

namespace TechECommerce.DataAccess.Persistance.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(b => b.Price).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(b => b.Name).IsRequired().HasMaxLength(128);
        builder.Property(b => b.Description).IsRequired().HasMaxLength(700);
        builder.Property(b => b.OperatingSystem).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Storage).IsRequired();
        builder.Property(b => b.Color).IsRequired().HasMaxLength(50);
        builder.Property(b =>b.IsDeleted).HasDefaultValue(false);

    }
}
