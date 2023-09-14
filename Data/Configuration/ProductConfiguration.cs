using market_place.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace market_place.Data.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Colors).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.CategoryId).IsRequired();
    }
}