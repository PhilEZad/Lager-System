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
        
        //Required Properties
    }
    
    public DbSet<Item> ItemTable { get; set; }
}