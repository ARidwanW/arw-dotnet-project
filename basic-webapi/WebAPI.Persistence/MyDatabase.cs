using Microsoft.EntityFrameworkCore;
using WebAPI.Domain;

namespace WebAPI.Persistence;

public class MyDatabase : DbContext
{
    public MyDatabase()
    { }
    public MyDatabase(DbContextOptions<MyDatabase> options) : base(options)
    { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(cat =>
        {
            cat.HasKey(c => c.CategoryId);
            cat.Property(c => c.CategoryName).IsRequired(true);
            cat.Property(c => c.Description).IsRequired(false);
            cat.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
        });
        modelBuilder.Entity<Product>(prod =>
        {
            prod.HasKey(p => p.ProductId);
            prod.Property(p => p.ProductName).IsRequired(true);
            prod.Property(p => p.Description).IsRequired(false);
        });
    }
}
