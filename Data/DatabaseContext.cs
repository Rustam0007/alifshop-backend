using market_place.Data.Configuration;
using market_place.Models;
using Microsoft.EntityFrameworkCore;

namespace market_place.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Category> Category { get; set; }
    public DbSet<SubCategory> SubCategory { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
    }

    
}