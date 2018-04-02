using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTAnalytics.Model
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // Enums.TypeSponsor
        public int TypeSponsor { get; set; }
    }
}
