using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTAnalytics.Model
{
    public class Set
    {
        public int SetId { get; set; }

        public virtual List<Player> players { get; set; }


        public int PlayerAId { get; set; }
        public int PlayerAPoints { get; set; }

        public int PlayerBId { get; set; }
        public int PlayerBPoints { get; set; }

        public int WinnerId { get; set; }
    }
}
