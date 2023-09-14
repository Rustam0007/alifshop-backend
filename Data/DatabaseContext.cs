using market_place.Data.Configuration;
using market_place.Models;
using Microsoft.EntityFrameworkCore;

namespace market_place.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Category> Category { get; set; }
    public DbSet<SubCategory> SubCategory { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<Store2Product> Store2Product { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new StoreConfiguration());
        modelBuilder.ApplyConfiguration(new Store2ProductConfiguration());
    }

    
}