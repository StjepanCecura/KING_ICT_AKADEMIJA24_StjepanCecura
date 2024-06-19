using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace KingICTAkademijaSC.Models
{
    public class Proizvod
    {
        [Key]
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public double Price { get; set; }
        public double DiscountPercentage { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public string? Brand { get; set; }
        public string? Sku { get; set; }
        public double Weight { get; set; }
        public string? WarrantyInformation { get; set; }
        public string? ShippingInformation { get; set; }
        public string? AvailabilityStatus { get; set; }
        public string? ReturnPolicy { get; set; }
        public int MinimumOrderQuantity { get; set; }
        public string? Thumbnail { get; set; }

        // Navigation properties
        public Dimensions? Dimensions { get; set; }
        public Meta? Meta { get; set; }
        public ICollection<string>? Tags { get; set; }
        public ICollection<string>? Images { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }

    public class Dimensions
    {
        [Key]
        public int Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
    }

    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
        public string? ReviewerName { get; set; }
        public string? ReviewerEmail { get; set; }

        // Foreign key relationship
        [ForeignKey("ProductModel")]
        public long ProizvodId { get; set; }
        public Proizvod? Proizvod { get; set; }
    }

    public class Meta
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Barcode { get; set; }
        public string? QrCode { get; set; }
    }

    public class Root
    {
        [JsonProperty("products")]
        public List<Proizvod> Proizvodi { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("skip")]
        public int Skip { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Dimensions> Dimensions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Meta> Metas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proizvod>()
                .HasOne(p => p.Dimensions)
                .WithOne()
                .HasForeignKey<Proizvod>(p => p.Id);

            modelBuilder.Entity<Proizvod>()
                .HasOne(p => p.Meta)
                .WithOne()
                .HasForeignKey<Proizvod>(p => p.Id);

            modelBuilder.Entity<Proizvod>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Proizvod)
                .HasForeignKey(r => r.ProizvodId);

            // Define other relationships and configurations if necessary
        }
    }
}
