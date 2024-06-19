using Microsoft.EntityFrameworkCore;

namespace KingICTAkademijaSC.Models
{
    public class ProizvodiContext : DbContext
    {
        public ProizvodiContext(DbContextOptions<ProizvodiContext> options)
            : base(options)
        {
        }
        public DbSet<Proizvod> Proizvodi { get; set; } = null;
    }
}
