using market_place.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace market_place.Data.Configuration;

public class Store2ProductConfiguration : IEntityTypeConfiguration<Store2Product>
{
    public void Configure(EntityTypeBuilder<Store2Product> builder)
    {
        builder.ToTable("Store2Product");

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.StoreId).IsRequired();
    }
}