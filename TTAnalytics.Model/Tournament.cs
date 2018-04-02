using System.Collections.Generic;

namespace TTAnalytics.Model
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Kind { get; set; }
        public string Organizer { get; set; }

        // Se o torneio é oficial
        public bool Official { get; set; }


        public virtual List<Match> Matches { get; set; }



    }
}