using Microsoft.EntityFrameworkCore;
using ShopHub.Domain.Entities;

namespace ShopHub.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Role>  Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        // --- Data Constraints

        // Category: Name must be unique
        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();

        // User: Username max length 15, Email max length 100
        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .HasMaxLength(15)
            .IsRequired();
    
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasMaxLength(100)
            .IsRequired();
        
        // --- Relationships
    
        // Primary Key Configurations (Usually found by convention, but explicit is clear)
        modelBuilder.Entity<Role>().HasKey(r => r.Id);
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Category>().HasKey(c => c.Id);
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
    
        // Role (1) <--> User (M)
        modelBuilder.Entity<Role>()
            .HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId); // FK is in User
    
        // Category (1) <--> Product (M)
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products) // One Category has many Products
            .WithOne(p => p.Category) // Each Product has one Category
            .HasForeignKey(p => p.CategoryId); // FK is in Product
    
        // User (1) <--> Product (M)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Products) // One User has many Products
            .WithOne(p => p.User) // Each Product has one User
            .HasForeignKey(p => p.UserId) // FK is in Product
            .OnDelete(DeleteBehavior.Cascade); // Deletes products if the user is deleted
    }
}