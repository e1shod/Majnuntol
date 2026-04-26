using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;  
using Majnuntol.Api.Entities;

namespace Majnuntol.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // ─── DbSet lar ───────────────────────────────────────────
    public DbSet<User> Users { get; set; }
    public DbSet<SellerProfile> SellerProfiles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ─── User -> SellerProfile (One-to-One) ──────────────
        modelBuilder.Entity<SellerProfile>()
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<SellerProfile>(sp => sp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // ─── User -> Product (One-to-Many) ───────────────────
        modelBuilder.Entity<Product>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // ─── Category -> Product (One-to-Many) ───────────────
        modelBuilder.Entity<Product>()
            .HasOne<Category>()
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // ─── Product -> ProductImage (One-to-Many) ────────────
        modelBuilder.Entity<ProductImage>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // ─── User -> Wishlist (One-to-Many) ──────────────────
        modelBuilder.Entity<Wishlist>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // ─── Product -> Wishlist (One-to-Many) ───────────────
        modelBuilder.Entity<Wishlist>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(w => w.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // ─── Review -> ReviewerUser (Restrict) ───────────────
        modelBuilder.Entity<Review>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.ReviewerUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // ─── Review -> SellerUser (Restrict) ─────────────────
        modelBuilder.Entity<Review>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.SellerUserId)
            .OnDelete(DeleteBehavior.Restrict);

       
    }
}