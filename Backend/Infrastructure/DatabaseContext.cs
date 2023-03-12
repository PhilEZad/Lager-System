using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Setting Primary Keys
        modelBuilder.Entity<Item>()
            .HasKey(x => x.Id)
            .HasName("PK_Item");
        
        //Generate Keys
        modelBuilder.Entity<Item>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        //Category Table
        modelBuilder.Entity<Category>()
            .HasKey(x => x.CategoryId)
            .HasName("PK_Category");
        //Generated Keys
        modelBuilder.Entity<Category>()
            .Property(x => x.CategoryId)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<Item> ItemTable { get; set; }

    public DbSet<Category> CategoryTable { get; set; }
}