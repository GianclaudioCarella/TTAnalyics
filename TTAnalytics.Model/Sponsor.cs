﻿namespace TTAnalytics.Model
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }

        // Revisar necessidade dos campos abaixo:
        public string City { get; set; }
        public string Country { get; set; }
        public int TypeSponsor { get; set; }
    }
}
