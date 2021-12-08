using Microsoft.EntityFrameworkCore;

namespace LinkConverter.API.Model
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }

        public DbSet<LinkConversion> LinkConversions { get; set; }
    }
}
