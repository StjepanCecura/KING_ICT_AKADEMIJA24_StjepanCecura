using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingICTAkademijaSC.Models
{
    public class Korisnik
    {
        [Key]
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MaidenName { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Image { get; set; }
        public string? BloodGroup { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string? EyeColor { get; set; }
        public Hair? Hair { get; set; }
        public string? Ip { get; set; }
        public Address? Address { get; set; }
        public string? MacAddress { get; set; }
        public string? University { get; set; }
        public Bank? Bank { get; set; }
        public Company? Company { get; set; }
        public string? Ein { get; set; }
        public string? Ssn { get; set; }
        public string? UserAgent { get; set; }
        public Crypto? Crypto { get; set; }
        public string? Role { get; set; }
    }

    public class Hair
    {
        [Key]
        public int Id { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }

        [ForeignKey("Korisnik")]
        public long KorisnikId { get; set; }
        public Korisnik? Korisnik { get; set; }
    }

        public class Address
        {
            [Key]
            public int Id { get; set; }
            public string? Street { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? StateCode { get; set; }
            public string? PostalCode { get; set; }
            public Coordinates? Coordinates { get; set; }
            public string? Country { get; set; }

            // Foreign key
            [ForeignKey("Korisnik")]
            public long KorisnikId { get; set; }
            public Korisnik? Korisnik { get; set; }
        }

        public class Coordinates
        {
            [Key]
            public int Id { get; set; }
            public double Lat { get; set; }
            public double Lng { get; set; }

            // Foreign key
            [ForeignKey("Address")]
            public int AddressId { get; set; }
            public Address? Address { get; set; }
        }

        public class Bank
        {
            [Key]
            public int Id { get; set; }
            public string? CardExpire { get; set; }
            public string? CardNumber { get; set; }
            public string? CardType { get; set; }
            public string? Currency { get; set; }
            public string? Iban { get; set; }

            // Foreign key
            [ForeignKey("Korisnik")]
            public long KorisnikId { get; set; }
            public Korisnik? Korisnik { get; set; }
        }

        public class Company
        {
            [Key]
            public int Id { get; set; }
            public string? Department { get; set; }
            public string? Name { get; set; }
            public string? Title { get; set; }
            public Address? Address { get; set; }

            // Foreign key
            [ForeignKey("Korisnik")]
            public long KorisnikId { get; set; }
            public Korisnik? Korisnik { get; set; }
        }

        public class Crypto
        {
            [Key]
            public int Id { get; set; }
            public string? Coin { get; set; }
            public string? Wallet { get; set; }
            public string? Network { get; set; }

            // Foreign key
            [ForeignKey("Korisnik")]
            public long KorisnikId { get; set; }
            public Korisnik? Korisnik { get; set; }
        }
        public class KorisnikContext : DbContext
        {
            public DbSet<Korisnik> Korisnici { get; set; }
            public DbSet<Hair> Hairs { get; set; }
            public DbSet<Address> Addresses { get; set; }
            public DbSet<Coordinates> Coordinates { get; set; }
            public DbSet<Bank> Banks { get; set; }
            public DbSet<Company> Companies { get; set; }
            public DbSet<Crypto> Cryptos { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Korisnik>()
                    .HasOne(u => u.Hair)
                    .WithOne(h => h.Korisnik)
                    .HasForeignKey<Hair>(h => h.KorisnikId);

                modelBuilder.Entity<Korisnik>()
                    .HasOne(u => u.Address)
                    .WithOne(a => a.Korisnik)
                    .HasForeignKey<Address>(a => a.KorisnikId);

                modelBuilder.Entity<Korisnik>()
                    .HasOne(u => u.Bank)
                    .WithOne(b => b.Korisnik)
                    .HasForeignKey<Bank>(b => b.KorisnikId);

                modelBuilder.Entity<Korisnik>()
                    .HasOne(u => u.Company)
                    .WithOne(c => c.Korisnik)
                    .HasForeignKey<Company>(c => c.KorisnikId);

                modelBuilder.Entity<Korisnik>()
                    .HasOne(u => u.Crypto)
                    .WithOne(c => c.Korisnik)
                    .HasForeignKey<Crypto>(c => c.KorisnikId);

                modelBuilder.Entity<Address>()
                    .HasOne(a => a.Coordinates)
                    .WithOne(c => c.Address)
                    .HasForeignKey<Coordinates>(c => c.AddressId);

                // Define other relationships and configurations if necessary
            }
        }
    }
