using Microsoft.EntityFrameworkCore;

namespace KingICTAkademijaSC.Models
{
    public class KorisniciContext : DbContext
    {
        public KorisniciContext(DbContextOptions<KorisniciContext> options)
            :base(options) 
        { 
        }
        public DbSet<Korisnik> Korisnici { get; set; } = null;
    }
}
