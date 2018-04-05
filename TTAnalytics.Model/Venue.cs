namespace TTAnalytics.Model
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual State State { get; set; }
    }
}
