using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTAnalytics.Model
{
    public class Player
    {
        public int PlayerId { get; private set; }
        public bool Activity { get; private set; }
        public string Handness { get; private set; } // passar a enum
        public string PlayingStyle { get; private set; } // passar a enum
        public string Grip { get; private set; } // passar a enum


        public int CurrentWRPosition { get; private set; } // propriedade calculada
        public int BestWRPosition { get; private set; } // propriedade calculada
        public int WRProgress { get; private set; } // propriedade calculada
        public int TotalMatches { get; } // propriedade calculada
        public int TotalWins { get; } // propriedade calculada
        public int TotalLoses { get; } // propriedade calculada
        public int CurrentYearWins { get; }  // propriedade calculada
        public int CurrentYearLoses { get; }  // propriedade calculada

        public List<Tournament> tournaments { get; private set; }
    }
}
