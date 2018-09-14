using System.Collections.Generic;

namespace TTAnalytics.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
    }
}
