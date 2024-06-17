using Microsoft.EntityFrameworkCore;

namespace KingICTAkademijaSC.Models
{
    public class AkademijaContext : DbContext
    {
        public AkademijaContext(DbContextOptions<AkademijaContext> options)
        : base(options)
        {
        }

        public DbSet<Proizvod> Proizvodi { get; set; } = null!;
        public DbSet<Korisnik> Korisnici { get; set; } = null!;
    }
}
