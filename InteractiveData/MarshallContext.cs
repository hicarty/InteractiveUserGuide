using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using InteractiveDomain;
using System.Threading.Tasks;

namespace InteractiveData
{
    public class MarshallContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                "Server=localhost,1433; Database=InteractiveAmplifiers;User=SA; Password=MyPassword123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<InteractiveAmplifier> InteractiveAmplifiers{ get; set; } //table {getset}
        public DbSet<InteractiveElement> InteractiveElements { get; set; }

    }
}
