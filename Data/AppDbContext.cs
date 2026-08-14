using Microsoft.EntityFrameworkCore;



public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Product>(entity =>
    {
        entity.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150);

        entity.Property(p => p.Description)
            .HasMaxLength(1000);

        entity.Property(p => p.ImageUrl)
            .HasMaxLength(500);

        entity.Property(p => p.Price)
            .HasPrecision(18, 2);
    });

        // Category Configuration
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
        });
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
