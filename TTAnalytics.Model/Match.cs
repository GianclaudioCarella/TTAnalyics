using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTAnalytics.Model
{
    public class Match
    {
        public int MatchId { get; set; }
        public int TournamentId { get; set; }

        public virtual List<Player> PlayerId { get; set; }

        public List<Set> Sets { get; set; }

        public int WinnerMatchId { get; set; }



    }
}
