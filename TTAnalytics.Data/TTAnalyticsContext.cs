using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TTAnalytics.Model;

namespace TTAnalytics.Data
{
    public class TTAnalyticsContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Equipament> Equipments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Round> Round { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Grip> Grips { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Handedness> Handedness { get; set; }
        public DbSet<PlayingStyle> PlayingStyles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
