using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTAnalytics.Model.DAO
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

    }
}
