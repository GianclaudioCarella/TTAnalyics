using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TTAnalytics.Model;

namespace TTAnalytics.Data
{
    public class TTAnalyticsContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Equipament> Equipments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
