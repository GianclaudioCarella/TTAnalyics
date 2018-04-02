using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTAnalytics.Model
{
    public class Equipament
    {
        public int EquipamentId { get; set; }
        public string Paddle { get; set; }
        public string FrontRubber { get; set; }
        public string BackRubber { get; set; }
        
        // Equipament in use
        public bool Activity { get; private set; }
    }
}
