using Microsoft.EntityFrameworkCore;
using EcommerceApi.Server.Constants;
using EcommerceApi.Server.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ✅ Store Enums as String in Database
        modelBuilder.Entity<Order>()
            .Property(o => o.order_status)
            .HasConversion<string>();

        modelBuilder.Entity<Payment>()
            .Property(p => p.payment_status)
            .HasConversion<string>();

        modelBuilder.Entity<User>()
            .Property(u => u.role)
            .HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }
}
