using System;
using System.Collections.Generic;

namespace TTAnalytics.Model
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Organizer Organizer { get; set; }
        public Venue Venue { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

        // Revisar necessidade dos campos abaixo:
        public string Type { get; set; }
        public string Kind { get; set; }
        public bool Official { get; set; }
    }
}